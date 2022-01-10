namespace BL.Models.Game
{
    public class Attack
    {
        public int Damage { get; set; }

        public bool IsCriticalMiss { get; set; }

        public bool IsCriticalDamage { get; set; }
        public int Dice20 { get; set; }
        public int Dice { get; set; }
    }
}