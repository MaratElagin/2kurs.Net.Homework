using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database.Models
{
    public class Monster
    {
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("hitPoints")]
        [Range(1, 100)]
        public int HitPoints { get; set; }
        
        [JsonPropertyName("attackModifier")]
        [Range(1, 100)]
        public int AttackModifier { get; set; }
        
        [JsonPropertyName("attackPerRound")]
        [Range(1, 100)]
        public int AttackPerRound { get; set; }
        
        [JsonPropertyName("damage")]
        public string Damage { get; set; }
        
        [JsonPropertyName("damageModifier")]
        [Range(1, 100)]
        public int DamageModifier { get; set; }
        
        [JsonPropertyName("armorClass")]
        [Range(1, 100)]
        public int ArmorClass { get; set; }
    }
}