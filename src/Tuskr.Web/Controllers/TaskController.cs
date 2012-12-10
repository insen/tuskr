using System.Linq;
using System.Web.Mvc;
using Tuskr.Data.Entities;
using Tuskr.Data.Infrastructure;
using Tuskr.Data.NHibernate;
using Tuskr.Web.Models;


namespace Tuskr.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IRepo<Task> _tasks;

        public TaskController(IRepo<Task> repo)
        {
            this._tasks = repo;
        }

        public ActionResult All()
        {
            return View(_tasks.All().Select(e => new TaskModel(e)));
        }

        public ActionResult AddView()
        {
            return View(TaskModel.Empty());
        }

        public ActionResult AddTask(TaskModel model)
        {
            _tasks.Add(new Task
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
            return View(_tasks.All().Select(e => new TaskModel(e)));
        }

        public ActionResult Edit(TaskModel model)
        {
            throw new HttpAntiForgeryException("bloddy erropr");
            var task = _tasks.FilterBy(t => t.Id == model.Id).FirstOrDefault();
            task.Status = model.Status;
            return RedirectToAction("ShowWall", "Task");
        }
    }

}