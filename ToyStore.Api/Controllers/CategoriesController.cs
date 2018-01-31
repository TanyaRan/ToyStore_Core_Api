namespace ToyStore.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Categories;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
            => this.OkOrNotFound(await this.categories.All(search));

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.categories.Details(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] CreateCategoryRequestModel model)
        {
            var id = await this.categories.Create(
                model.Name);

            return Ok(id);
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody]string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Ok();
            }

            var editCategory = await this.categories.Edit(id, name);

            if (!editCategory)
            {
                return NotFound("Category not found");
            }

            return Ok();
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCategory = await this.categories.Delete(id);

            if (!deleteCategory)
            {
                return NotFound("Category not found");
            }

            return Ok();
        }
    }
}
