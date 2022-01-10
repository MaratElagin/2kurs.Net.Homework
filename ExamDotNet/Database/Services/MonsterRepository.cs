using System;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Services
{
    public class MonsterRepository :IMonsterRepository
    {
        protected readonly ApplicationContext _applicationContext;
        private readonly DbSet<Monster> _monstersDBSet;

        public MonsterRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _monstersDBSet = applicationContext.Set<Monster>();
        }

        public async Task<Monster> GetRandomMonster()
        {
            var count = await _monstersDBSet.CountAsync();

            if (count != 0)
            {
                Random rand = new Random();
                var randomAmountToSkip = rand.Next(0, count);
                return await _monstersDBSet.Skip(randomAmountToSkip).FirstAsync();
            }

            throw new ArgumentNullException("В базе данных нет монстров!");
        }

        public async Task<Monster> AddAndSaveAsync(Monster monster)
        {
            var entityAdd = await _monstersDBSet.AddAsync(monster);
            await _applicationContext.SaveChangesAsync();
            return entityAdd.Entity;
        }

        public async Task<Monster> FindAsync(int id)
        {
            return await _monstersDBSet.FindAsync(id);
        }
    }
}