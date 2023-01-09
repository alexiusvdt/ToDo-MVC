using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ToDoList.Models;
using System.Threading.Tasks;
using ToDoList.ViewModels;

namespace ToDoList.AddControllersWithViews
{
  public class AccountController : Controller
  {
    private readonly ToDoListContext _db;
    //registration methods
    private readonly UserManager<ApplicationUser> _userManager;
    //sign in/out methods
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ToDoListContext db) 
    {
      //note dependency injection here, giving it the user/signin svcs so it can access as needed
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
  
    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    //async included in signature returning a Task of type <ActionResult> which we unzip after completion
    //RegisterViewModel argument represents user data when registering new account
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        //creates new AppUser with email as username
        ApplicationUser user = new ApplicationUser { UserName = model.Email };
        //IdentityResult class represents result of identity-driven action, regardless of success/fail
        //pass in the whole user 
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);

        //IdentityResult has a property of Succeeded (bool)
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          //IdentityResult also has IdentityError of type IEnumerable<IdentityError>
          //this is an iterable collection of IdentityError objects, each with a description property
          foreach (IdentityError error in result.Errors)
          {
            //key & descript of error to display
            ModelState.AddModelError("", error.Description);
          }
          //this will redisplay Register() GET action with the same model that has errors associated with it.
          //not passing model here would 'forget' the previous model and start a new one
          return View(model);
        }
      }
    }
  
  }
}