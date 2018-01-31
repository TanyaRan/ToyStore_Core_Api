namespace ToyStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Category;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly ToyStoreDbContext db;

        public CategoryService(ToyStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.db.Add(category);
            await this.db.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<CategoryListingModel>> All(string searchText)
            => await this.db
                .Categories
                .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                .OrderBy(c => c.Name)
                .ProjectTo<CategoryListingModel>()
                .ToListAsync();

        public async Task<CategoryWithToysModel> Details(int id)
            => await this.db
            .Categories
            .Where(c => c.Id == id)
            .ProjectTo<CategoryWithToysModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> Edit(int id, string name)
        {
            var category = this.db.Categories.Find(id);

            if (category == null)
            {
                return false;
            }

            category.Name = name;
            this.db.Update(category);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var category = this.db.Categories.Find(id);

            if (category == null)
            {
                return false;
            }

            this.db.Remove(category);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
