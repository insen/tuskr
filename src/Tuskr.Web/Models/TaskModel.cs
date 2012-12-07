using System;
using Tuskr.Data.Entities;

namespace Tuskr.Web.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public int Duration { get; set; }

        public TaskStatus Status { get; set; }

        public TaskModel(Task task)
        {
            Name = task.Name;
            Description = task.Description;
            Duration = task.Duration;
            StartDate = task.StartDate;
            Status = task.Status;
            Id = task.Id;
        }

        private TaskModel()
        {
        }

        public static TaskModel Empty()
        {
            return new TaskModel();
        }
    }
}