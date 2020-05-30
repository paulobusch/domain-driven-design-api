using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Application
{
    public class CustomerAppService : AppServiceBase<Customer>, ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        public CustomerAppService(
            ICustomerService customerService
        ) : base(customerService) => _customerService = customerService;

        public async Task<IEnumerable<Customer>> GetSpecialCustomers()
        {
            return _customerService.GetSpecialCustomers(await _customerService.GetAll());
        }
    }
}
