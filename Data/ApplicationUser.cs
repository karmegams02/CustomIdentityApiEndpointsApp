using Microsoft.AspNetCore.Identity;

namespace BlazorIdentityApiDemo.Data;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;
}