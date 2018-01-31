namespace ToyStore.Data.Models
{
    public class ToyCategory
    {
        public int ToyId { get; set; }

        public Toy Toy { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
