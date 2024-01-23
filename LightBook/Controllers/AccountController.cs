using Microsoft.AspNetCore.Mvc;

namespace LightBook.Mvc.Controllers
{
    public class AccountController : BookBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
