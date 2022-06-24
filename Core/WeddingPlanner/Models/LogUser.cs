#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class LogUser
{

    [Required]
    [EmailAddress]
    public string LogEmail {get;set;}
    [Required]
    [DataType(DataType.Password)]
    public string LogPassword {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdateAt {get;set;} = DateTime.Now;
}