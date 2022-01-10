using System.Collections.Generic;

namespace UI.Models.Game
{
    public class Activity
    {
        public bool IsUserActivity { get; set; }

        public IEnumerable<Attack> Attacks { get; set; }
    }
}