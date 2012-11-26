using System.Collections.Generic;

namespace Tuskr.Data.Infrastructure
{
    public interface IRepo<TE> : IReadOnlyRepo<TE> where TE : class
    {
        bool Add(TE entity);
        bool Add(IEnumerable<TE> items);
        bool Update(TE entity);
        bool Delete(TE entity);
        bool Delete(IEnumerable<TE> entities);
    }
}