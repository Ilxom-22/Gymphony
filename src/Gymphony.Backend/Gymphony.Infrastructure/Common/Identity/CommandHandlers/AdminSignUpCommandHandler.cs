using AutoMapper;
using Gymphony.Application.Common.EventBus.Brokers;
using Gymphony.Application.Common.Identity.Commands;
using Gymphony.Application.Common.Identity.Events;
using Gymphony.Application.Common.Identity.Models.Dtos;
using Gymphony.Application.Common.Identity.Services;
using Gymphony.Domain.Brokers;
using Gymphony.Domain.Common.Commands;
using Gymphony.Domain.Entities;
using Gymphony.Persistence.Repositories.Interfaces;

namespace Gymphony.Infrastructure.Common.Identity.CommandHandlers;

public class AdminSignUpCommandHandler(
    IMapper mapper,
    IRequestContextProvider requestContextProvider,
    IAdminRepository adminRepository,
    IPasswordHasherService passwordHasherService, 
    IEventBusBroker eventBusBroker) 
    : ICommandHandler<AdminSignUpCommand, UserDto>
{
    public async Task<UserDto> Handle(AdminSignUpCommand request, CancellationToken cancellationToken)
    {
        var adminData = mapper.Map<Admin>(request.SignUpDetails);
        adminData.AuthDataHash = passwordHasherService.HashPassword(request.SignUpDetails.AuthData);
        
        var admin = await adminRepository
            .CreateAsync(adminData, cancellationToken: cancellationToken);
        
        await eventBusBroker.PublishLocalAsync(new AdminCreatedEvent { Admin = admin, TemporaryPassword = request.SignUpDetails.AuthData }, cancellationToken);

        return mapper.Map<UserDto>(admin);
    }
}