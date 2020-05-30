using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.interfaces.Services
{
    public interface ICustomerService : IServiceBase<Customer> { 
        IEnumerable<Customer> GetSpecialCustomers(IEnumerable<Customer> customers);    
    }
}
