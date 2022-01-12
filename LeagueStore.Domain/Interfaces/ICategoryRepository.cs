using I_LeagueStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I_LeagueStore.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);

        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> DeleteAsync(Category category);

    }
}
