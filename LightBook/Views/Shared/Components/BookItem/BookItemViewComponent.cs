using LightBook.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LightBook.Mvc.Views.Shared.Components.BookItem
{
    public class BookItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BookApp book)
        {
            return View(book);
        }
    }
}
