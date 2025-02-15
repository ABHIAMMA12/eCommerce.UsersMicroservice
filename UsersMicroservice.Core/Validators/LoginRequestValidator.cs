using FluentValidation;
using UsersMicroservice.Core.DTO;
namespace UsersMicroservice.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            //Email
            RuleFor(opt => opt.Email)
                .NotEmpty().WithMessage("Email is Required").EmailAddress().WithMessage("Invalid Email Address the email should be end with @gmail.com");
            //Password
            RuleFor(opt => opt.Password).NotEmpty().WithMessage("Password is required").WithMessage("Length must be 6 or more");
        }
    }
}
