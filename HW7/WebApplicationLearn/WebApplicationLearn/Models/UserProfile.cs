using System.ComponentModel.DataAnnotations;

#nullable enable
namespace WebApplicationLearn.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "Fill this field!")]
        [MaxLength(30, ErrorMessage = "First Name must be less than 30 symbols")]
        //[Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Fill this field!")]
        [MaxLength(30, ErrorMessage = "Last Name must be less than 30 symbols")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Fill this field!")]
        [MaxLength(30, ErrorMessage = "Middle Name must be less than 30 symbols")]
        [Display(Name = "Middle name")]
        public string? MiddleName { get; set; }
        
        [Required(ErrorMessage = "Fill this field!")]
        [Range(10, 100, ErrorMessage = "Your age must be in the range of 10 to 100")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        
        public Sex Sex { get; set; }
    }
    
    public enum Sex
    {
        Male,
        Female
    };
}