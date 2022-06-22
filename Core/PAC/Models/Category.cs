#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace PAC.Models;


public class Category
{
    [Key]
    public int CategoryId{get;set;}
    [Required]
    [MinLength(2)]
    public string Name {get;set;}
    
    public List<Association> ProductsInCategory { get; set; } = new List<Association>();
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdateAt {get;set;} = DateTime.Now;
}