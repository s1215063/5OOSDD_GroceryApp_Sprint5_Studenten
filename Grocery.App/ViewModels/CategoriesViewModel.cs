﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;


namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        private readonly ICategoryService _categoryService;
        [ObservableProperty]
        Client client;

        public CategoriesViewModel(ICategoryService categoryService, GlobalViewModel global)
        {
            Title = "Productcategorieën";
            _categoryService = categoryService;
            Categories = new(_categoryService.GetAll());
            Client = global.Client;
        }

        [RelayCommand]
        public async Task SelectCategory(Category Category)
        {
            Dictionary<string, object> paramater = new() { { nameof(Category), Category } };
            await Shell.Current.GoToAsync($"{nameof(Views.ProductCategoriesView)}?Titel={Category.Name}", true, paramater);
        }

        [RelayCommand]
        public async Task ShowBoughtProducts()
        {
            if (Client.Role == Role.Admin) await Shell.Current.GoToAsync(nameof(BoughtProductsView), true);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            Categories = new(_categoryService.GetAll());
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Categories.Clear();
        }
    }
}