using System.ComponentModel.DataAnnotations;

namespace BL.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int AttackModifier { get; set; }
        public int AttackPerRound { get; set; }
        public string Damage { get; set; }
        public int DamageModifier { get; set; }
        public int ArmorClass { get; set; }
        public bool IsUser { get; set; }
    }
}