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
}