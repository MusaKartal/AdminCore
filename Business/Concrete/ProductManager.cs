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

        public async Task DeleteItem(int id, Product product)
        {
             var item = await _repository.Get(id);             
             var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{item.Photo}");
            if (item.Photo == "NullPhoto.jpg") 
            {
             await _repository.Delete(product.Id);
             
            }
            else
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                await _repository.Delete(product.Id);
            }
            

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

       
        public async Task ImageUploadItem(IFormFile file, Product product)
        {

            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyToAsync(stream);

                product.Photo = imageName;
                await _repository.Add(product);
            }
            else
            { 
                product.Photo = "NullPhoto.jpg";
                await _repository.Add(product);   
            }
        }

        public async Task ImageUpdateItem(IFormFile file, int id, Product product)
        {
                
            var a = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{product.Photo}");

            if (System.IO.File.Exists(a))
            {
                System.IO.File.Delete(a);
            }

            if (file == null)
            {
                product.Photo = "NullPhoto.jpg";
                await _repository.Update(id,product);
            }
            else
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyToAsync(stream);

                product.Photo = imageName;
                await _repository.Update(id, product);

            }


        }
    }
    }
