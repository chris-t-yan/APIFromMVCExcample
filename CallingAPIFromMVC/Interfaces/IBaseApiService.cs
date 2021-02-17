using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Interfaces
{
    public interface IBaseApiService<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
    }
}
