using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {

            productCategories = new List<ProductCategory>
            {
                new ProductCategory(1, "", 1, 3), //Dairy Melk
                new ProductCategory(2, "", 2, 3), //Dairy Kaas
                new ProductCategory(3, "", 3, 4), //Baked goods Brood
                new ProductCategory(4, "", 4, 5), //Breakfast Cornflakes
            };
        }

        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        public List<ProductCategory> GetAllByCategoryId(int categoryId)
        {
            return productCategories.Where(pc => pc.CategoryId == categoryId).ToList();
        }

        public List<ProductCategory> GetAllByProductId(int productId)
        {
            return productCategories.Where(pc => pc.ProductId == productId).ToList();
        }

        public ProductCategory Add(ProductCategory item)
        {
            int newId = productCategories.Max(pc => pc.Id) + 1;
            item.Id = newId;
            productCategories.Add(item);
            return Get(item.Id);
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(pc => pc.Id == id);
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? productCategory = productCategories.FirstOrDefault(pc => pc.Id == item.Id);
            productCategory = item;
            return productCategory;
        }
    }
}
