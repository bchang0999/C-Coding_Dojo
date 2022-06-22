#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace PAC.Models;


public class Product
{
    [Key]
    public int ProductId{get;set;}
    [Required]
    [MinLength(2)]
    public string Name {get;set;}
    [Required]
    [MinLength(2)]
    public string Description {get;set;}
    [Required]
    [Range(1, int.MaxValue)]
    public int Price {get;set;}

    public List<Association> ListedCategories { get; set; } = new List<Association>();
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdateAt {get;set;} = DateTime.Now;
}