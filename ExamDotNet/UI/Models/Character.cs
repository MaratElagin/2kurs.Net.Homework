using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Character
    {
        [Required] public string Name { get; set; }
        [Required] public int HitPoints { get; set; }
        [Required] public int AttackModifier { get; set; }
        [Required] public int AttackPerRound { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,2}d([1-9]|[1][0-9]|20)$",
            ErrorMessage = "Формат записи: <число_бросков>d<число_граней>")]
        public string Damage { get; set; }

        [Required] public int DamageModifier { get; set; }
        [Required] public int ArmorClass { get; set; }
    }
}