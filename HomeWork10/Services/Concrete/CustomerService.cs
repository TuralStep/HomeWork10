using HomeWork10.Entities;
using HomeWork10.Repository.Abstract;
using HomeWork10.Services.Abstract;
using System.Linq.Expressions;

namespace HomeWork10.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;


        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Customer entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task DeleteAsync(Customer entity)
        {
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _repo.GetAsync(predicate);
        }

        public async Task UpdateAsync(Customer entity)
        {
            await _repo.UpdateAsync(entity);
        }
    }
}
