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
            var entities = _tasks.All();
            var vmodels = entities.Select(e => new TaskModel(e));
            return View(vmodels);
        }
    }
}