using System.ComponentModel.DataAnnotations;

namespace TreatShop.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    public string UserName { get; set; }

    // [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}