namespace ToyStore.Services.Models.Category
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryWithToysModel : IMapFrom<Category>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Toys { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
            .CreateMap<Category, CategoryWithToysModel>()
            .ForMember(c => c.Toys, cfg => cfg
                .MapFrom(c => c.Toys.Select(t => t.Toy.Name)));
    }
}
