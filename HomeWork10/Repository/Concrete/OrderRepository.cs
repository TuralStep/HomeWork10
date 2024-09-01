using HomeWork10.Db;
using HomeWork10.Entities;
using HomeWork10.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeWork10.Repository.Concrete
{
    public class OrderRepository:IOrderRepository
    {
        private readonly MarketDBContext _context;

        public OrderRepository(MarketDBContext context)
        {
            _context = context;
        }



        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            await Task.Run(() =>
            {
                _context.Orders.Remove(entity);
            });

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _context.Orders;
            });
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var item = await _context.Orders.FirstOrDefaultAsync(expression);
            return item;
        }

        public async Task UpdateAsync(Order entity)
        {
            await Task.Run(() =>
            {
                _context.Orders.Update(entity);
            });
            await _context.SaveChangesAsync();
        }
    }
}
