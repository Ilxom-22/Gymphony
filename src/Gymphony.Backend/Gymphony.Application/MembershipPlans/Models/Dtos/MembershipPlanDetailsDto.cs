using Gymphony.Application.Common.Identity.Models.Dtos;
using Gymphony.Domain.Entities;

namespace Gymphony.Application.MembershipPlans.Models.Dtos;

public class MembershipPlanDetailsDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    
    public string Description { get; set; } = default!;

    public string DurationUnit { get; set; } = default!;

    public byte DurationCount { get; set; }

    public string Status { get; set; } = default!;

    public StripeDetails? StripeDetails { get; set; }

    public decimal Price { get; set; }
    
    public DateTimeOffset CreatedTime { get; set; }
    
    public DateTimeOffset? ModifiedTime { get; set; }

    public UserDto? CreatedBy { get; set; }

    public UserDto? ModifiedBy { get; set; }
}