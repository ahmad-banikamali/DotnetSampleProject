using Microsoft.AspNetCore.Identity;

namespace Domain;

public record Product(Guid Id, string Name, IdentityUser Use);