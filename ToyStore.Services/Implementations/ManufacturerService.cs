namespace ToyStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Manufacturer;
    using Models.Toy;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ManufacturerService : IManufacturerService
    {
        private readonly ToyStoreDbContext db;

        public ManufacturerService(ToyStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string name, string country)
        {
            var manufacturer = new Manufacturer
            {
                Name = name,
                Country = country
            };

            this.db.Add(manufacturer);
            await this.db.SaveChangesAsync();

            return manufacturer.Id;
        }

        public async Task<IEnumerable<ManufacturerListingModel>> All(string searchText)
            => await this.db
            .Manufacturers
            .Where(m => m.Name.ToLower().Contains(searchText.ToLower()))
            .ProjectTo<ManufacturerListingModel>()
            .ToListAsync();

        public async Task<ManufacturerDetailsModel> Details(int id)
            => await this.db
                .Manufacturers
                .Where(m => m.Id == id)
                .ProjectTo<ManufacturerDetailsModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ToyWithCategoriesModel>> Toys(int manufacturerId)
            => await this.db
                .Toys
                .Where(t => t.ManufacturerId == manufacturerId)
                .ProjectTo<ToyWithCategoriesModel>()
                .ToListAsync();

        public async Task<bool> Exists(int id)
            => await this.db
                .Manufacturers
                .AnyAsync(m => m.Id == id);
    }
}
