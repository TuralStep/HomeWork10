using HomeWork10.Db;
using HomeWork10.Entities;
using HomeWork10.Repository.Abstract;
using HomeWork10.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeWork10.Repository.Concrete
{
    public class ProductRepository:IProductRepository
    {
        private readonly MarketDBContext _context;

        public ProductRepository(MarketDBContext context)
        {
            _context = context;
        }



        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            await Task.Run(() =>
            {
                _context.Products.Remove(entity);
            });

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _context.Products;
            });
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var item = await _context.Products.FirstOrDefaultAsync(expression);
            return item;
        }

        public async Task UpdateAsync(Product entity)
        {
            await Task.Run(() =>
            {
                _context.Products.Update(entity);
            });
            await _context.SaveChangesAsync();
        }
    }
}
