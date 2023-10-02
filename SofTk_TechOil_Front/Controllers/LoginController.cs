using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using Data.DTOs;
using Data.Base;
using Newtonsoft.Json;

namespace SofTk_TechOil_Front.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public LoginController(IHttpClientFactory httpClient) 
        {
            _httpClient = httpClient;
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            var baseApi = new BaseApi(_httpClient);
            var token = await baseApi.PostToApi("Login", login);
            var resultadoLogin = token as OkObjectResult;
             var resultadoObjeto = JsonConvert.DeserializeObject<Models.Login>(resultadoLogin.Value.ToString());

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            Claim claimRole = new(ClaimTypes.Role, "1");

            identity.AddClaim(claimRole);

            var claimPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(1),
            });

            HttpContext.Session.SetString("Token", resultadoObjeto.Token);

            //var homeViewModel = new HomeViewModel();
            //homeViewModel.Token = resultadoObjeto.Token;

           // return View("~/Views/Home/Index.cshtml", homeViewModel);
            return View("~/Views/Home/Index.cshtml");
        }


        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
