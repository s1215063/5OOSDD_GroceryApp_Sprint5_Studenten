using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;

        public CategoryRepository()
        {
            categories = new List<Category>
            {
                new Category(1, "Fruits"),
                new Category(2, "Vegetables"),
                new Category(3, "Dairy"),
                new Category(4, "Baked goods"),
                new Category(5, "Breakfast")
            };
        }

        public List<Category> GetAll()
        {
            return categories;
        }

        public Category? Get(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public Category Add(Category item)
        {
            int newId = categories.Max(c => c.Id) + 1;
            item.Id = newId;
            categories.Add(item);
            return Get(item.Id)!;
        }

        public Category? Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Update(Category item)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == item.Id);
            category = item;
            return category;
        }
    }
}
