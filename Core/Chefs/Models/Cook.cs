#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Chefs.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required]
    [MinLength(2)]
    public string Fname {get;set;}
    [Required]
    [MinLength(2)]
    public string Lname {get;set;}
    [Required]
    public DateTime DOB {get;set;}
    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();
    public DateTime CreatedAt{get;set;}=DateTime.Now;
    public DateTime UpdatedAt{get;set;}=DateTime.Now;

}