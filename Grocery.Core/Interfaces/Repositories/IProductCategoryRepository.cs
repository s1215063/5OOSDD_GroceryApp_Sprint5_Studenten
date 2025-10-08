﻿using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        public List<ProductCategory> GetAll();

        public List<ProductCategory> GetAllByCategoryId(int categoryId);

        public ProductCategory Add(ProductCategory item);

        public ProductCategory? Delete(ProductCategory item);

        public ProductCategory? Get(int id);

        public ProductCategory? Update(ProductCategory item);
    }
}
