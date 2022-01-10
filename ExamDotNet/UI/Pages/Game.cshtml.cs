using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;
using UI.Models.Game;

namespace UI.Pages
{
    public class Game : PageModel
    {
        [BindProperty] public Character UserCharacter { get; set; }
        public Character Monster { get; set; }
        private readonly HttpClient _client = new();
        public FightResult FightResult { get; set; }

        private readonly Uri _urlGetRandomMonster =
            new("https://localhost:5003/Db/GetRandomMonster");

        public async Task<IActionResult> OnGet()
        {
            if (!TempData.TryGetValue("userCharacter", out var uc))
                return RedirectToPage("/Index");
            try
            {
                UserCharacter = JsonSerializer.Deserialize<Character>((string) uc);
            }
            catch (Exception exception)
            {
                return RedirectToPage("/Index");
            }

            Monster = await _client.GetFromJsonAsync<Character>(_urlGetRandomMonster);
            return Page();
        }
    }
}