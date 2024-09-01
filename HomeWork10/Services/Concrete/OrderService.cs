using HomeWork10.Entities;
using HomeWork10.Repository.Abstract;
using HomeWork10.Services.Abstract;
using System.Linq.Expressions;

namespace HomeWork10.Services.Concrete
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repo;


        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Order entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task DeleteAsync(Order entity)
        {
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _repo.GetAsync(predicate);
        }

        public async Task UpdateAsync(Order entity)
        {
            await _repo.UpdateAsync(entity);
        }
    }
}
