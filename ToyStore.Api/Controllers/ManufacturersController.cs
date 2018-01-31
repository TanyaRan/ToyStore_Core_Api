namespace ToyStore.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Manufacturers;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;

    public class ManufacturersController : BaseController
    {
        private readonly IManufacturerService manufacturers;

        public ManufacturersController(IManufacturerService manufacturers)
        {
            this.manufacturers = manufacturers;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
            => this.OkOrNotFound(await this.manufacturers.All(search));

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.manufacturers.Details(id));

        [HttpGet(WithId + "/toys")]
        public async Task<IActionResult> GetToys(int id)
            => this.OkOrNotFound(await this.manufacturers.Toys(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]ManufacturerRequestModel model)
        {
            var id = await this.manufacturers.Create(
                model.Name,
                model.Country);

            return Ok(id);
        }
    }
}
