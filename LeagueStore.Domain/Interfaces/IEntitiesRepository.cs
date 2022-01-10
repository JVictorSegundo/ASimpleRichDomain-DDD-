using LeagueStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueStore.Domain.Interfaces
{
    public interface IEntitiesRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync ();
        Task<Item> GetByIdAsync (int id);

        Task<Item> CreateAsync (T t);
        Task<Item> UpdateAsync (T t);
        Task<Item> DeleteAsync (T t);

    }
}
