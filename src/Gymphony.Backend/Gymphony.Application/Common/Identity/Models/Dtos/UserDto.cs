using Gymphony.Application.Common.StorageFiles.Models.Dtos;

namespace Gymphony.Application.Common.Identity.Models.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Role { get; set; } = default!;

    public string Status { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public bool TemporaryPasswordChanged { get; set; } = default!;

    public UserProfileImageDto? ProfileImage { get; set; }
}