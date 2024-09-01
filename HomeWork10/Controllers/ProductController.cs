using HomeWork10.Dots;
using HomeWork10.Entities;
using HomeWork10.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<IEnumerable<ProductDot>> Get()
        {
            var items = await _service.GetAllAsync();
            var dataToReturn = items.Select(s =>
            {
                return new ProductDot
                {
                    Name = s.Name,
                    Price = s.Price,
                    Discount = s.Discount
                };
            });
            return dataToReturn;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetAsync(s => s.Id == id);
            if (item == null) return NotFound();
            var dto = new ProductDot
            {
                Name = item.Name,
                Price = item.Price,
                Discount = item.Discount
            };
            return Ok(dto);
        }


        [HttpGet("Higher")]
        public IEnumerable<ProductDot> HigherDiscounts()
        {
            var dtos = _service.GetAllAsync()
                .Result
                .Where(p => p.Discount > 50)
                .Select(p => new ProductDot
                {
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount
                });
            return dtos;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDot dto)
        {
            var entity = new Product
            {
                Name = dto.Name,
                Price= dto.Price,
                Discount = dto.Discount
            };
            await _service.AddAsync(entity);
            return Ok(dto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDot dto)
        {
            var product = _service.GetAsync(c => c.Id == id).Result;
            if (product != null)
            {
                product.Name = dto.Name;
                product.Price = dto.Price;
                product.Discount = dto.Discount;
                await _service.UpdateAsync(product);
                return Ok(product);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _service.GetAsync(p => p.Id == id).Result;
            if (product == null) return NotFound();
            await _service.DeleteAsync(product);
            return NoContent();
        }
    }
}
