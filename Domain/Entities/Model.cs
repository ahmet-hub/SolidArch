namespace Domain.Entities
{
    public class Model
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public virtual ICollection<ModelImage> Images { get; set; }
        public virtual Brand Brand { get; set; }
    }

    public class ModelImage
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string ImageUrl { get; set; }
        public virtual Model Model { get; set; }
    }
}
