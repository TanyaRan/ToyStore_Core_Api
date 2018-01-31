namespace ToyStore.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Toys;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;

    public class ToysController : BaseController
    {
        private readonly IToyService toys;
        private readonly IManufacturerService manufacturers;

        public ToysController(
            IToyService toys, 
            IManufacturerService manufacturers)
        {
            this.toys = toys;
            this.manufacturers = manufacturers;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
    => this.OkOrNotFound(await this.toys.All(search));

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.toys.Details(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]CreateToyRequestModel model)
        {
            if (!await this.manufacturers.Exists(model.ManufacturerId))
            {
                return BadRequest("Manufacturer does not exist.");
            }

            var id = await this.toys.Create(
                model.Name,
                model.Description,
                model.Price,
                model.Count,
                model.ManufacturerId,
                model.Categories);

            return this.Ok(id);
        }
    }
}
