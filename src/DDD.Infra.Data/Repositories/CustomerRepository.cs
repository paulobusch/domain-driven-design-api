using DDD.Domain.Entities;
using DDD.Domain.interfaces;
using DDD.Domain.interfaces.Repositories;
using DDD.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infra.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DDDContext context) : base(context) {}
    }
}
