using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.API.Controllers
{
    public class CustomersController : DDDControllerBase
    {
        private readonly ICustomerAppService _customerApp;
        
        public CustomersController(ICustomerAppService customerApp)
        {
            _customerApp = customerApp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> ListAsync()
        {
            return (await _customerApp.GetAll()).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetAsync(int id)
        {
            return await _customerApp.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] Customer customer)
        {
            await _customerApp.Add(customer);
            return Ok(new { Success = true });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] Customer customer) { 
            customer.Id = id;
            await _customerApp.Update(customer);
            return Ok(new { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var customer = await _customerApp.GetById(id);
            await _customerApp.Remove(customer);
            return Ok(new { Success = true });
        }
    }
}