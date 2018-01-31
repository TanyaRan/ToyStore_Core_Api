namespace ToyStore.Services
{
    using Models.Manufacturer;
    using Models.Toy;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IManufacturerService
    {
        Task<int> Create(string name, string country);

        Task<IEnumerable<ManufacturerListingModel>> All(string searchText);

        Task<ManufacturerDetailsModel> Details(int id);

        Task<IEnumerable<ToyWithCategoriesModel>> Toys(int manufacturerId);

        Task<bool> Exists(int id);
    }
}
