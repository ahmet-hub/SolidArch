namespace Core.Security.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

    }
}
