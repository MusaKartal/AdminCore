using AdminCore.Models;

namespace AdminCore.Business.Abstract
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetItemAll();
        Task<Product> GetProductById(int id);
        Task<Product> CreateItem(Product product);
        Task UpdateItem(int id,Product product);
        Task DeleteItem(int id);
        Task UploadItem(IFormFile file,Product product);
        Task UploadUpdateItem(IFormFile file,int id, Product product);

    }
}
