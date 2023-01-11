using Microsoft.AspNetCore.Mvc;

namespace Client.Web.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
