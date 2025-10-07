using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        public List<ProductCategory> GetAll();

        public List<ProductCategory> GetAllByCategoryId(int categoryId);

        public ProductCategory Add(ProductCategory item);

        public ProductCategory? Delete(ProductCategory item);

        public ProductCategory? Get(int id);

        public ProductCategory? Update(ProductCategory item);
    }
}