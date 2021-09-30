using API.Core.DbModels;
using API.Core.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IGenericRepository1<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
