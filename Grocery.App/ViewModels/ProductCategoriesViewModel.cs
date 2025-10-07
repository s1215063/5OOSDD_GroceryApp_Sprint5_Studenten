using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private string searchText = "";

        public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];
        public ObservableCollection<Product> AvailableProducts { get; set; } = [];

        [ObservableProperty]
        Category category = new(0, "None");

        [ObservableProperty]
        string myMessage = "";

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        private void Load(int categoryId)
        {
            ProductCategories.Clear();
            // Get all ProductCategory relationships for this category
            foreach (var item in _productCategoryService.GetAllByCategoryId(categoryId)) 
            {
                ProductCategories.Add(item);
            }
            GetAvailableProducts();
        }

        private void GetAvailableProducts()
        {
            AvailableProducts.Clear();
            foreach (Product p in _productService.GetAll())
            {
                // Show products that are NOT already in this category, have stock, and match search
                bool isAlreadyInCategory = ProductCategories.Any(pc => pc.ProductId == p.Id);
                bool hasStock = p.Stock > 0;
                bool matchesSearch = string.IsNullOrEmpty(searchText) || p.Name.ToLower().Contains(searchText.ToLower());

                if (!isAlreadyInCategory && hasStock && matchesSearch)
                {
                    AvailableProducts.Add(p);
                }
            }
        }

        partial void OnCategoryChanged(Category value)
        {
            if (value != null)
            {
                Title = $"Products in {value.Name}";
                Load(value.Id);
            }
        }

        [RelayCommand]
        public void AddProductToCategory(Product product)
        {
            if (product == null || Category == null) return;

            try
            {
                // Create new ProductCategory relationship
                ProductCategory newRelationship = new(0, "", product.Id, Category.Id);
                _productCategoryService.Add(newRelationship);

                // Refresh the view
                Load(Category.Id);
            }
            catch (Exception ex)
            {
            }
        }

        [RelayCommand]
        public void RemoveProductFromCategory(ProductCategory productCategory)
        {
            if (productCategory == null) return;

            try
            {
                _productCategoryService.Delete(productCategory);
                Load(Category.Id);
            }
            catch (Exception ex)
            {
            }
        }

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText ?? "";
            GetAvailableProducts();
            
            // Clear message when searching
            if (!string.IsNullOrEmpty(this.searchText))
            {
            }
            else
            {
            }
        }

        [RelayCommand]
        public void ClearSearch()
        {
            searchText = "";
            GetAvailableProducts();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            if (Category != null)
            {
                Load(Category.Id);
            }
        }
    }
}