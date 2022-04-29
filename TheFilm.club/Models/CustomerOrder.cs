using System.Collections.Generic;

namespace TheFilm.club.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public string Email{ get; set; }
        public string UserId { get; set; }
        public int MyProperty { get; set; }
        public List<CustomerOrderItem> CustomerOrderItems{ get; set; }
    }
}
