using FluentValidation;
using UsersMicroservice.Core.DTO;

namespace UsersMicroservice.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //Email
            RuleFor(opt => opt.Email)
                .NotEmpty().WithMessage("Email is Required").EmailAddress().WithMessage("Invalid Email Address");
            //Password
            RuleFor(opt => opt.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).WithMessage("Length must be 6 or more");

            //Personname
            RuleFor(opt => opt.PersonName).NotEmpty().WithMessage("Person Name is required")
                .MaximumLength(50).WithMessage("Max Name Length shpuld be 50");
            //Gender

            RuleFor(opt => opt.Gender).IsInEnum().WithMessage("Invalid Gender Option");

            //custom validator eill be applied using must

        }
    }
}
