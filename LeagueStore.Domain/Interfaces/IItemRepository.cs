using I_LeagueStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I_LeagueStore.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetByIdAsync(int id);
        Task<IEnumerable<Item>> GetAllAsync();
        Task<IEnumerable<Item>> GetAllByCategoryId(int id);

        Task<Item> CreateAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task<Item> DeleteAsync(Item item);
    }
}
