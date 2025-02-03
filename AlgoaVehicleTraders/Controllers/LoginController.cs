using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace AlgoaVehicleTraders.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            //ViewData["ErrorUsername"] = null;
            //ViewData["ErrorPassword"] = null;
            //ViewData["ErrorGeneral"] = null;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password, bool rememberMe)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ViewData["ErrorUsername"] = "Username is required.";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ViewData["ErrorPassword"] = "Password is required.";
            }

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Replace with your desired post-login destination
                }
                else if (result.IsLockedOut)
                {
                    ViewData["ErrorGeneral"] = "This account is locked. Please try again later.";
                }
                else
                {
                    ViewData["ErrorGeneral"] = "Invalid username or password.";
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();  // Signs the user out
            return RedirectToAction("Index", "Home");  // Redirect to the home page after logout
        }
    }
}
