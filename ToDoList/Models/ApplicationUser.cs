using Microsoft.AspNetCore.Identity;

namespace ToDoList.Models
{
    public class ApplicationUser : IdentityUser
    {
      //example of other features one could add in overtop the base IdentityUser fields
      // public string Website { get; set; }
      // public string Image { get; set; }
      // public DateOnly Birthday { get; set; }
    }
}