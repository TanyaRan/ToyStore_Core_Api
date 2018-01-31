namespace ToyStore.Services
{
    using Models.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<int> Create(string name);

        Task<IEnumerable<CategoryListingModel>> All(string searchText);

        Task<CategoryWithToysModel> Details(int id);

        Task<bool> Edit(int id, string name);

        Task<bool> Delete(int id);
    }
}
