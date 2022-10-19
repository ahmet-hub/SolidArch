namespace Core.Translation.Entities
{
    public class ContentLocale
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int LocaleId { get; set; }
        public string Value { get; set; }
        public virtual Content Content { get; set; }
        public virtual Locale Locale { get; set; }
    }
}
