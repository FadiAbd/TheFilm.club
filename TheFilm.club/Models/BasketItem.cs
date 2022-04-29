using System.ComponentModel.DataAnnotations;

namespace TheFilm.club.Models
{
    public class BasketItem
    {
        [Key]
        public int  Id  { get; set; }
        public Film Film { get; set; }
        public int Amount { get; set; }
        public string BasketId { get; set; }
    }
}
