using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_3.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public CustomerAddress CustomerAddress { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
