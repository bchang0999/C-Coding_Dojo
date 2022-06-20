#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginAndValidation.Models;

public class User
{
    [Key]
    public int UserId {get;set;}
    [Required]
    [MinLength(2)]
    public string FName {get;set;}
    [Required]
    [MinLength(2)]
    public string LName {get;set;}
    [Required]
    [EmailAddress]
    public string Email {get;set;}
    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
    public string Password {get;set;}
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    
    public string PassConfirm {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}