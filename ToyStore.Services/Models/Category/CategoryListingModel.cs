namespace ToyStore.Services.Models.Category
{
    using Common.Mapping;
    using Data.Models;

    public class CategoryListingModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
