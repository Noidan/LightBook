using System.ComponentModel.DataAnnotations;
using LightBook.Domain.Entities;
    
namespace LightBook.Mvc.Models.Home
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "Данное поле обязательно")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно")]
        public DateTime? DateTime { get; set; }

        public IEnumerable<BookApp>? Books { get; set; }
    }
}
