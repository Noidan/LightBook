using LightBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using LightBook.Domain;
using LightBook.Domain.Entities;
using LightBook.Mvc.Models.Home;

namespace LightBook.Mvc.Controllers
{
    [Authorize]
    public class HomeController : BookBaseController
    {
        private readonly LightBookContext _context;
        
        public HomeController(LightBookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(new HomeViewModel
            {
                Books = await GetBooksCurrentUserAsync()
            });
        }

        public async Task<IActionResult> CreateAsync(HomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Books = await GetBooksCurrentUserAsync();
                return View("Index", model);
            }

            var book = await _context.Books.FirstOrDefaultAsync(t => t.Name.ToLower() == model.BookName.ToLower()
                && t.UserId == CurrentUserId
                && t.ExpiredDate == model.DateTime);
            
            if (book != null)
            {
                model.Books = await GetBooksCurrentUserAsync();
                ViewBag.Error = "Такая книга уже существует!";

                return View("Index", model);
            }

            await _context.Books.AddAsync(new BookApp
            {
                Name = model.BookName,
                ExpiredDate = model.DateTime.Value,
                UserId = CurrentUserId
            });

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(t => t.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateComletedAsync(int id, bool Readed)
        {
            var book = await _context.Books.FirstOrDefaultAsync(t => t.Id == id);
            if (book != null)
            {
                book.Readed = Readed;
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateNameAsync(int id, string name)
        {
            var book = await _context.Books.FirstOrDefaultAsync(t => t.Id == id);
            if (book != null)
            {
                if (book.Name != name)
                {
                    book.Name = name;
                    _context.Books.Update(book);
                    _context.SaveChanges();
                }
                
            }

            return RedirectToAction("Index");
        }

        private async Task<IEnumerable<BookApp>> GetBooksCurrentUserAsync()
        {
            return await _context.Books
                .Where(t => t.UserId == CurrentUserId)
                .ToListAsync();
        }
    }
}