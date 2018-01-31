namespace ToyStore.Services.Models.Toy
{
    using Common.Mapping;
    using Data.Models;

    public class ToyListingModel : IMapFrom<Toy>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
