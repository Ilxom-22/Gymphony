namespace Gymphony.Application.Common.Identity.Models.Dtos;

public class StaffDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Bio { get; set; } = default!;

    public string Role { get; set; } = default!;

    public string Status { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;
}