using HomeWork10.Dots;
using HomeWork10.Entities;
using HomeWork10.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<IEnumerable<OrderDot>> Get()
        {
            var items = await _service.GetAllAsync();
            var dataToReturn = items.Select(s =>
            {
                return new OrderDot
                {
                    OrderDate = s.OrderDate,
                    ProductId = s.ProductId,
                    CustomerId = s.CustomerId
                };
            });
            return dataToReturn;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetAsync(s => s.Id == id);
            if (item == null) return NotFound();
            var dto = new OrderDot
            {
                CustomerId = item.CustomerId,
                OrderDate = item.OrderDate,
                ProductId = item.ProductId
            };
            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDot dto)
        {
            var entity = new Order
            {
                OrderDate = dto.OrderDate,
                ProductId = dto.ProductId,
                CustomerId = dto.CustomerId
            };
            await _service.AddAsync(entity);
            return Ok(dto);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDot dto)
        {
            var order = _service.GetAsync(c => c.Id == id).Result;
            if (order != null)
            {
                order.OrderDate = dto.OrderDate;
                order.ProductId = dto.ProductId;
                order.CustomerId = dto.CustomerId;
                _service.UpdateAsync(order);
                return Ok(order);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _service.GetAsync(p => p.Id == id).Result;
            if (order == null) return NotFound();
            _service.DeleteAsync(order);
            return NoContent();
        }
    }
}
