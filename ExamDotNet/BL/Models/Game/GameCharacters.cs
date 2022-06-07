using System.Text.Json.Serialization;

namespace BL.Models.Game
{
    public class GameCharacters
    {
        [JsonPropertyName("us")]
        public Character Us { get; set; }
        [JsonPropertyName("monst")]
        public Character Monst { get; set; }
    }
}