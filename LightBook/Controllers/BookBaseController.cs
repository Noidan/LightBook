using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LightBook.Mvc.Controllers
{
    public abstract class BookBaseController : Controller
    {
        protected int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
