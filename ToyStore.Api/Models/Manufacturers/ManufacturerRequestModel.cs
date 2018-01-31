namespace ToyStore.Api.Models.Manufacturers
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class ManufacturerRequestModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Country { get; set; }
    }
}
