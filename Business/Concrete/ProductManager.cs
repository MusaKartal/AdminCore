using AdminCore.Business.Abstract;
using AdminCore.Models;
using AdminCore.Repository;

namespace AdminCore.Business.Concrete
{
    public class ProductManager : IProduct
    {
        private readonly IRepository<Product> _repository;  

        public ProductManager(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> CreateItem(Product product)
        {
            await _repository.Add(product);
            return product;
        }

        public async Task DeleteItem(int id)
        {
            await _repository.Delete(id);

        }

        public async Task<IEnumerable<Product>> GetItemAll()
        {
            return await _repository.GetAll();
        }

        public Task<Product> GetProductById(int id)
        {
            return _repository.Get(id);
        }

        public async Task UpdateItem(int id, Product product)
        {
            await _repository.Update(id, product);
        }

        public Task UploadItem(IFormFile file, Product product)
        {
            throw new NotImplementedException();
        }

        public Task UploadUpdateItem(IFormFile file, int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
