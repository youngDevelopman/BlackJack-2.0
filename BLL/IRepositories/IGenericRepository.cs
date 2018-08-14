using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task Remove(TEntity item);
        Task Update(TEntity item);
        Task Save();
        Task<List<TEntity>> GetAllWithNoTracking();
    }
}
