using System;
using API.DTOs;
using FluentValidation;

namespace API.Validations
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();
            RuleFor(registerDto => registerDto.UserName.Length)
                .Equal(3);
            RuleFor(x => x.City)
                .NotEmpty();
            RuleFor(model => model.Country)
                .NotEmpty();
            RuleFor(model => model.Gender).NotEmpty();
            RuleFor(model => model.DateOfBirth).NotEmpty().WithMessage("DOB is Required")
                .WithErrorCode("3002");
            RuleFor(x => x.DateOfBirth.Date).GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithName("DOB")
                .OverridePropertyName("DOB")
                .WithErrorCode("69")
                .WithMessage("DOB must be greater than today");



        }
    }
}
