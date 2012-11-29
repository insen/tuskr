using System;

namespace Tuskr.Data.Entities
{
    public class Task : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual int Duration { get; set; }
        public virtual TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Undefined = 0,
        WaitStart = 1,
        Active = 2,
        Done = 3
    }
}