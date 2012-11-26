using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tuskr.Data.Infrastructure
{
    public interface IReadOnlyRepo<TE> where TE : class
    {
        IQueryable<TE> All();
        TE FindBy(Expression<Func<TE, bool>> expression);
        IQueryable<TE> FilterBy(Expression<Func<TE, bool>> expression);
    }
}