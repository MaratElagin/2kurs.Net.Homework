using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;
using UI.Models.Game;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty] public Character UserCharacter { get; set; }
        public Character Monster { get; set; }

        private readonly HttpClient _client = new();
        public FightResult FightResult { get; set; }

        private readonly Uri _urlGetRandomMonster =
            new("https://localhost:5003/Db/GetRandomMonster");

        private readonly Uri _urlStartGame =
            new("https://localhost:5005/BL/StartGame");

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            if (!ModelState.IsValid) return;
            Monster = await _client.GetFromJsonAsync<Character>(_urlGetRandomMonster);
            var gameCharacters = new GameCharacters
            {
                Us = UserCharacter,
                Monst = Monster
            };
            
            var response = await _client.PostAsJsonAsync(_urlStartGame, gameCharacters);
            FightResult = await response.Content.ReadFromJsonAsync<FightResult>();
            UserCharacter = FightResult?.UserCharacter;
        }
    }
}