using System.Collections.Generic;
using BL.Models.Game;

namespace BL.Models
{
    public class FightResult
    {
        //[JsonPropertyName("userCharacter")]
        public Character UserCharacter { get; set; }

        //[JsonPropertyName("monster")]
        public Character Monster { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public bool IsUserWin { get; set; }
    }
}