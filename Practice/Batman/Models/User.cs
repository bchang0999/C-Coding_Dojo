#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Batman.Models;


public class User{
    [Required]
    [MinLength(4, ErrorMessage = "First Name must have at least 4 characters")]
    public string FName {get;set;}

    [Required]
    [MinLength(4, ErrorMessage = "Last Name must have at least 4 characters") ]
    public string LName {get;set;}

    [Required]
    [Range(0,99,ErrorMessage ="Age Must Be A Positive Number")]
    public string Age{get;set;}

    [Required]
    [EmailAddress (ErrorMessage = "Email Must Be In A Valid Format")]
    public string Email{get;set;}

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]

    public string Password {get;set;}

}