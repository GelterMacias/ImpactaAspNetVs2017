using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.MVC.Areas.Admin.Models;

namespace ViagensOnline.MVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private string AuthenticationType = "ViagensOnlineCookieAuth";

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (viewModel.email != "usuario@viagensonline.com" || viewModel.senha != "1234")
            {
                ModelState.AddModelError(string.Empty,"E-mail ou senha inválidos");
                return View(viewModel);
            }

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier,viewModel.email));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var identidade = new ClaimsIdentity(claims,AuthenticationType);

            //Open Web Interface for .NET (Kestrel)
            Request.GetOwinContext().Authentication.SignIn(identidade);

            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(AuthenticationType);

            return RedirectToAction("Index","Home", new { area = "" }); //Como começou a usar area, é obrigado colocar o 3º parametro
        }
    }
}