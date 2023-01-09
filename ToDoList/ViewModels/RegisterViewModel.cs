using System.ComponentModel.DataAnnotations;

namespace ToDoList.ViewModels
{
  //RegisterViewModel is used because we don't want to save ConfirmPassword to ApplicationUser
  //RVM can be used for validation and wont interfere with/change data in AppUser logic
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    // Display() just changes how it's presented in UI
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$", ErrorMessage = "Your password must contain at least six characters, a capital letter, a lowercase letter, a number, and a special character.")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}