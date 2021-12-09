using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW11.Services.Database.Models
{
    public class CalculatingExpression
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Expression { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Result { get; set; }
    }
}