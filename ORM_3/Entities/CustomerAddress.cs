using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_3.Entities
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
