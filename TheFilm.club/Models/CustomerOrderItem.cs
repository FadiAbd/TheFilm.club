using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFilm.club.Models
{
    public class CustomerOrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int FilmId { get; set; }
        [ForeignKey("FilmId")]
        public  Film Film { get; set; }
        public int CustomerOrderId { get; set; }
        [ForeignKey("CustomerOrderId")]
        public CustomerOrder CustomerOrder { get; set; }

    }
}
