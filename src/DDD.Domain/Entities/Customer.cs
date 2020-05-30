using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

        public bool SpecialCustomer()
        {
            return this.Active && DateTime.Now.Year - this.CreatedDate.Year >= 5;
        }
    }
}
