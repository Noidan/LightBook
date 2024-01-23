using System.ComponentModel.DataAnnotations.Schema;

namespace LightBook.Domain.Entities
{
    public class BookApp : Entity
    {
        public string Name { get; set; }
        public bool Readed { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }  
    }
}
