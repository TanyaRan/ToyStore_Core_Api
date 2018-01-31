namespace ToyStore.Services.Models.Manufacturer
{
    using Common.Mapping;
    using Data.Models;

    public class ManufacturerListingModel : IMapFrom<Manufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }
    }
}
