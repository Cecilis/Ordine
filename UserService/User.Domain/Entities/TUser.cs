namespace User.Domain.Entities
{
    public class TUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty; // "Google", "GitHub", etc.
        public string ExternalId { get; set; } = string.Empty; // ID del proveedor
        public string FullName { get; set; } = string.Empty;
    }
}
