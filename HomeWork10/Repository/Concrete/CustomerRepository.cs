using HomeWork10.Db;
using HomeWork10.Entities;
using HomeWork10.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeWork10.Repository.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly MarketDBContext _context;

        public CustomerRepository(MarketDBContext context)
        {
            _context = context;
        }



        public async Task AddAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer entity)
        {
            await Task.Run(() =>
            {
                _context.Customers.Remove(entity);
            });

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _context.Customers;
            });
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            var item = await _context.Customers.FirstOrDefaultAsync(expression);
            return item;
        }

        public async Task UpdateAsync(Customer entity)
        {
            await Task.Run(() =>
            {
                _context.Customers.Update(entity);
            });
            await _context.SaveChangesAsync();
        }
    }
}
