using System.Threading.Tasks;
using Database.Models;
using Database.Services;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DbController : ControllerBase
    {
        private readonly IMonsterRepository _monsterRepository;

        public DbController(IMonsterRepository monsterRepository)
        {
            _monsterRepository = monsterRepository;
        }

        [HttpGet]
        [Route("GetRandomMonster")]
        public async Task<Monster> Get()
        {
            return await _monsterRepository.GetRandomMonster();
        }
    }
}