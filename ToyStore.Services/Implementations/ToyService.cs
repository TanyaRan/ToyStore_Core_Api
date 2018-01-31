namespace ToyStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Extensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Toy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ToyService : IToyService
    {
        private readonly ToyStoreDbContext db;

        public ToyService(ToyStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(
            string name,
            string description,
            decimal price,
            int count,
            int manufacturerId,
            string categories)
        {
            var categoryNames = categories
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            var existingCategories = await this.db
                .Categories
                .Where(c => categoryNames.Contains(c.Name))
                .ToListAsync();

            var allCategories = new List<Category>(existingCategories);

            foreach (var catName in categoryNames)
            {
                if (existingCategories.All(c => c.Name != catName))
                {
                    var category = new Category
                    {
                        Name = catName
                    };

                    this.db.Add(category);

                    allCategories.Add(category);
                }
            }

            await this.db.SaveChangesAsync();

            var toy = new Toy
            {
                Name = name,
                Description = description,
                Price = price,
                Count = count,
                ManufacturerId = manufacturerId
            };

            allCategories.ForEach(c => toy.Categories.Add(new ToyCategory
            {
                CategoryId = c.Id
            }));

            this.db.Add(toy);
            await this.db.SaveChangesAsync();

            return toy.Id;
        }

        public async Task<IEnumerable<ToyListingModel>> All(string searchText)
            => await this.db
            .Toys
            .Where(t => t.Name.ToLower().Contains(searchText.ToLower()))
            .OrderBy(t => t.Name)
            .Take(10)
            .ProjectTo<ToyListingModel>()
            .ToListAsync();

        public async Task<ToyDetailsModel> Details(int id)
            => await this.db
                .Toys
                .Where(t => t.Id == id)
                .ProjectTo<ToyDetailsModel>()
                .FirstOrDefaultAsync();
    }
}
