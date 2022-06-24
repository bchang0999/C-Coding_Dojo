#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId{get;set;}
    [Required]
    [MinLength(2)]
    public string Fname {get;set;}
    [Required]
    [MinLength(2)]
    public String Lname {get;set;}
    [Required]
    [EmailAddress]
    public string Email {get;set;}
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password {get;set;}
    [NotMapped]
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string PassConfirm {get;set;}

    public List<Wedding> Weddings {get;set;} = new List<Wedding>();

    public List<Guest> Guests {get;set;} = new List<Guest>();


    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdateAt {get;set;} = DateTime.Now;
}