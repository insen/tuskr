namespace Tuskr.Data.Entities
{
    public class Entity<TId>
    {
        public virtual TId Id { get; set; }
    }
}