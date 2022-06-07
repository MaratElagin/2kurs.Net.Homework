using System.ComponentModel.DataAnnotations;

namespace DotNetExam2sem.Dto;

public class CreditDto
{
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string MiddleName { get; set; }
    
    [Required]
    [Range(21, 72)]
    public int Age { get; set; }
    
    [Required]
    public string Conviction { get; set; }
    
    public string PassportSeries { get; set; }
    
    [Required]
    public string PassportNumber { get; set; }
    
    [Required]
    public DateTime PassportDate { get; set; }
    
    [Required]
    public string PassportAddress { get; set; }
    
    [Required]
    public string PassportAgency { get; set; }
    
    [Required]
    [Range(0, 10000000)]
    public int CreditSum { get;set; }
    
    [Required]
    public string Employment { get; set; }
    
    [Required]
    public string Purpose { get;set; }
    
    [Required]
    public string OtherCredits { get; set; }
    
    [Required]
    public string Deposit { get; set; }
    
    [Required]
    [Range(0, 100)]
    public int CarAge { get; set; }
}