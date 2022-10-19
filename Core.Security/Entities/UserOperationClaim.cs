namespace Core.Security.Entities
{
    public class UserOperationClaim
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
