namespace ToyStore.Api.Models.Toys
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class CreateToyRequestModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Range(1, 1000)]
        public decimal Price { get; set; }

        [Range(1, 1000)]
        public int Count { get; set; }

        public int ManufacturerId { get; set; }

        public string Categories { get; set; }
    }
}
