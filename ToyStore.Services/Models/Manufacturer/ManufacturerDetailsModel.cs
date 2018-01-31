namespace ToyStore.Services.Models.Manufacturer
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ManufacturerDetailsModel : IMapFrom<Manufacturer>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Toys { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Manufacturer, ManufacturerDetailsModel>()
                .ForMember(m => m.Toys, cfg => cfg
                    .MapFrom(m => m.Toys.Select(t => t.Name)));
    }
}
