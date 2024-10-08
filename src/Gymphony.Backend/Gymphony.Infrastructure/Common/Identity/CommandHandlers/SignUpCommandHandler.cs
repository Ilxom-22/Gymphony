using FluentValidation;
using Gymphony.Application.Common.Identity.Commands;
using Gymphony.Application.Common.Identity.Models.Dtos;
using Gymphony.Domain.Common.Commands;
using Gymphony.Domain.Enums;
using Gymphony.Persistence.Repositories.Interfaces;
using MediatR;

namespace Gymphony.Infrastructure.Common.Identity.CommandHandlers;

public class SignUpCommandHandler(
    IMediator mediator,
    IUserRepository userRepository,
    IValidator<SignUpDetails> signUpDetailsValidator) 
    : ICommandHandler<SignUpCommand, UserDto>
{
    public async Task<UserDto> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.UserExists(request.SignUpDetails.EmailAddress))
            throw new ValidationException("User with this email address is already registered!");

        RuleSets passwordValidationRule;

        if (request.Role == Role.Admin)
            passwordValidationRule = RuleSets.AdminSignUp;
        
        else if (request.AuthProvider == Provider.EmailPassword)
            passwordValidationRule = RuleSets.EmailSignUp;
        else
            passwordValidationRule = RuleSets.ThirdPartySignUp;

        var validationResult = await signUpDetailsValidator
            .ValidateAsync(request.SignUpDetails, options =>
                options.IncludeRuleSets(passwordValidationRule.ToString()).IncludeRulesNotInRuleSet(), 
                cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors[0].ToString());

        if (request.Role == Role.Admin)
            return await mediator.Send(new AdminSignUpCommand
            {
                SignUpDetails = request.SignUpDetails
            }, cancellationToken);
        
        return await mediator.Send(new MemberSignUpCommand
        {
            SignUpDetails = request.SignUpDetails,
            AuthProvider = request.AuthProvider
        }, cancellationToken);
    }
}