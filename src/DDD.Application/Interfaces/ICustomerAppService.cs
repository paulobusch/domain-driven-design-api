using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.Interfaces
{
    public interface ICustomerAppService : IAppServiceBase<Customer>
    {
        Task<IEnumerable<Customer>> GetSpecialCustomers();
    }
}
