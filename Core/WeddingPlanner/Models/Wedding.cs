#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId{get;set;}
    [Required]
    [MinLength(2)]
    public string WedderOne {get;set;}
    [Required]
    [MinLength(2)]
    public string WedderTwo {get;set;}
    [Required]
    public DateTime Date {get;set;}
    [Required]
    public string Address {get;set;}
    [Required]
    public int UserId {get;set;}

    public User? User {get;set;}

    public List<Guest> Guests {get;set;} = new List<Guest>();

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdateAt {get;set;} = DateTime.Now;
}

