namespace Core.Security.Entities
{
    public class EmailAuthenticator
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ActivationKey { get; set; }
        public bool IsVerified { get; set; }
        public virtual User User { get; set; }
    }
}
