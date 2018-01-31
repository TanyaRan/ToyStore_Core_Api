namespace ToyStore.Services.Models.Toy
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Linq;

    public class ToyDetailsModel : ToyWithCategoriesModel, IMapFrom<Toy>, IHaveCustomMapping
    {
        public string Manufacturer { get; set; }

        public override void ConfigureMapping(Profile mapper)
            => mapper
            .CreateMap<Toy, ToyDetailsModel>()
            .ForMember(t => t.Categories, cfg => cfg
                .MapFrom(t => t.Categories.Select(c => c.Category.Name)))
            .ForMember(t => t.Manufacturer, cfg => cfg
                .MapFrom(t => t.Manufacturer.Name + ", " + t.Manufacturer.Country));
    }
}
