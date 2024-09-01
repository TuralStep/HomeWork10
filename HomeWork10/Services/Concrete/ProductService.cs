using HomeWork10.Entities;
using HomeWork10.Repository.Abstract;
using HomeWork10.Services.Abstract;
using System.Linq.Expressions;

namespace HomeWork10.Services.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repo;


        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Product entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task DeleteAsync(Product entity)
        {
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _repo.GetAsync(predicate);
        }

        public async Task UpdateAsync(Product entity)
        {
            await _repo.UpdateAsync(entity);
        }
    }
}
