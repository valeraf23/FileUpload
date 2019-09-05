using System.Collections.Generic;
using System.Threading.Tasks;

namespace UploadFile.DataAccess
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> SaveAsync(T entity);
        void Add(T entity);
    }
}
