using DDD.Domain.Entities;
using DDD.Domain.interfaces.Repositories;
using DDD.Domain.interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerRepository repository
        ) : base(repository) => _customerRepository = repository;

        public IEnumerable<Customer> GetSpecialCustomers(IEnumerable<Customer> customers)
        {
            return customers.Where(c => c.SpecialCustomer());
        }
    }
}
