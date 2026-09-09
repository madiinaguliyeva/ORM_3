using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_3.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
