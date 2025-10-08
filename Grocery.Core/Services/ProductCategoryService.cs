using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IProductRepository productRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }
        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll();
            FillService(productCategories);
            return productCategories;
        }
        public List<ProductCategory> GetAllByCategoryId(int categoryId)
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            FillService(productCategories);
            return productCategories;
        }
        public ProductCategory Add(ProductCategory item)
        {
            return _productCategoryRepository.Add(item);
        }
        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }
        public ProductCategory? Get(int id)
        {
            return _productCategoryRepository.Get(id);
        }
        public ProductCategory? Update(ProductCategory item)
        {
            return _productCategoryRepository.Update(item);
        }
        private void FillService(List<ProductCategory> productCategories)
        {
            foreach (ProductCategory pc in productCategories)
            {
                pc.Product = _productRepository.Get(pc.ProductId) ?? new(0, "", 0);
            }
        }
    }
}
