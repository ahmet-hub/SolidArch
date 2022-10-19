namespace Domain.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
