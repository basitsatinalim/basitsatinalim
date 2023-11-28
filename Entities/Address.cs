namespace basitsatinalimuyg.Entities
{
    public class Address : BaseEntity
    {
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        public string? AddressTitle { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
    }
}
