using System;
using System.Linq;
using System.Web.Mvc;
using Tuskr.Data.Entities;
using Tuskr.Data.Infrastructure;
using Tuskr.Web.Models;


namespace Tuskr.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IRepo<Task> _tasksRepo;

        public TaskController(IRepo<Task> repo)
        {
            _tasksRepo = repo;
        }

        public ActionResult All()
        {
            return View(_tasksRepo.All().Select(e => new TaskModel(e)));
        }

        public ActionResult AddView()
        {
            return View(TaskModel.Empty());
        }

        public ActionResult AddTask(TaskModel model)
        {
            _tasksRepo.Add(new Task
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    Duration = model.Duration,
                    Status = model.Status
                });

            return RedirectToAction("All");
        }

        public ActionResult ShowWall()
        {
            return View(_tasksRepo.All().Select(e => new TaskModel(e)));
        }

        public ActionResult EditStatus(TaskModel model)
        {
            try
            {
                var task = _tasksRepo.FindBy(t => t.Id == model.Id);
                task.Status = model.Status;
                _tasksRepo.Update(task);
                return Json(new {success = true, results = "ok"});
            }
            catch (Exception e)
            {
                return Json(new {success = false, results = e.Message});
            }
        }

        public ActionResult Edit(TaskModel model)
        {
            try
            {
                var task = _tasksRepo.FindBy(t => t.Id == model.Id);
                task.Name = model.Name;
                task.Description = model.Description;
                task.Duration = model.Duration;
                task.StartDate = model.StartDate;
                task.Status = model.Status;
                _tasksRepo.Update(task);
                return Json(new {success = true, results = "ok"});
            }
            catch (Exception e)
            {
                return Json(new {success = false, results = e.Message});
            }
        }
    }
}