namespace ToyStore.Services.Models.Toy
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ToyWithCategoriesModel : IMapFrom<Toy>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public virtual void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Toy, ToyWithCategoriesModel>()
                .ForMember(t => t.Categories, cfg => cfg
                    .MapFrom(t => t.Categories.Select(c => c.Category.Name)));
    }
}
