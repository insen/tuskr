using Tuskr.Data.Entities;

namespace Tuskr.Web.Models
{
    public class TaskModel
    {
        public TaskModel(Task task)
        {
            this.Name = task.Name;
        }

        public string Name { get; set; }
    }
}