using HomeWork10.Dots;
using HomeWork10.Entities;
using HomeWork10.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork10.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<IEnumerable<CustomerDot>> Get()
        {
            var items = await _service.GetAllAsync();
            var dataToReturn = items.Select(s =>
            {
                return new CustomerDot
                {
                    Name = s.Name,
                    Surname = s.Surname
                };
            });
            return dataToReturn;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetAsync(s => s.Id == id);
            if (item == null) return NotFound();
            var dto = new CustomerDot
            {
                Name= item.Name,
                Surname= item.Surname
            };
            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDot dto)
        {
            var entity = new Customer
            {
                Name = dto.Name,
                Surname = dto.Surname
            };
            await _service.AddAsync(entity);
            return Ok(dto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDot dto)
        {
            var customer = _service.GetAsync(c => c.Id == id).Result;
            if (customer != null)
            {
                customer.Name = dto.Name;
                customer.Surname = dto.Surname;
                await _service.UpdateAsync(customer);
                return Ok(customer);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = _service.GetAsync(p => p.Id == id).Result;
            if (customer == null) return NotFound();
            await _service.DeleteAsync(customer);
            return NoContent();
        }


    }
}
