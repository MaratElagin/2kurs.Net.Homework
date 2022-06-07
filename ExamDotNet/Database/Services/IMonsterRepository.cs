using System.Threading.Tasks;
using Database.Models;

namespace Database.Services
{
    public interface IMonsterRepository
    {
        Task<Monster> GetRandomMonster();
        Task<Monster> AddAndSaveAsync(Monster monster);
        Task<Monster> FindAsync(int id);
    }
}