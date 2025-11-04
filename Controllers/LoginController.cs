using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaDeCadastroEmp.ViewModel;

namespace SistemaDeCadastroEmp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // LOGIN
        [HttpGet]
        public IActionResult formLogin()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

            //se formulario for invalido retorno para mesma pagina
            if (!ModelState.IsValid)
            {
                return View("formLogin", model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Senha,
                model.LembrarMe,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ;

            ModelState.AddModelError(string.Empty, "Email ou senha invalido");
            return View("formLogin", model);
        }

        // Registrar

        public  IActionResult RegistrarForm()
        {
            return View("formRegistrar");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegistrarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("formRegistrar", model);
            }
            ;

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,

            };

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            };


            return View("formRegistrar", model);
        }
        
        //Logout 
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("formLogin");
        }

    }
}