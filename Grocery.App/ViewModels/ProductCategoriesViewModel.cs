using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];

        [ObservableProperty]
        private Category category = new(0, "None");

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public void LoadProductCategoriesByCategory(Category category)
        {
            ProductCategories.Clear();

            var productCategories = _productCategoryService.GetAllByCategoryId(category.Id);
            foreach (var productCategory in productCategories)
                ProductCategories.Add(productCategory);
        }
        partial void OnCategoryChanged(Category value)
        {
            LoadProductCategoriesByCategory(value);
        }
    }
}