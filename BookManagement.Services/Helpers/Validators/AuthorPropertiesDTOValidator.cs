using BookManagement.Services.Models.AuthorModels.DTOs;
using FluentValidation;

namespace BookManagement.Services.Helpers.Validators;

public class AuthorPropertiesDTOValidator : AbstractValidator<AuthorPropertiesDTO>
{
    public AuthorPropertiesDTOValidator()
    {
        RuleFor(t => t.Biography)
            .NotEmpty().WithMessage("The biography cannot be empty.");
        RuleFor(t => t.DateOfBirth)
            .LessThan(DateTime.Now).WithMessage("The date of birth must be in the past.");
    }
}