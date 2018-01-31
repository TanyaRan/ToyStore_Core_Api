namespace ToyStore.Services
{
    using Models.Toy;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IToyService
    {        
        Task<IEnumerable<ToyListingModel>> All(string searchText);

        Task<int> Create(
            string name,
            string description,
            decimal price,
            int count,
            int manufacturerId,
            string categories);

        Task<ToyDetailsModel> Details(int id);
    }
}
