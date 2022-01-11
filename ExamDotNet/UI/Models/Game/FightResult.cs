using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UI.Models.Game
{
    public class FightResult
    {
        [JsonPropertyName("userCharacter")]
        public Character UserCharacter { get; set; }
        [JsonPropertyName("monster")]
        public Character Monster { get; set; }
        [JsonPropertyName("activities")]
        public IEnumerable<Activity> Activities { get; set; }
        [JsonPropertyName("isUserWin")]
        public bool IsUserWin { get; set; }
    }
}