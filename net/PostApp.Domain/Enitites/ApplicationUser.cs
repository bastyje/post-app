namespace PostApp.Domain.Entities;

public record ApplicationUser
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public bool IsEmployee { get; set; }
}