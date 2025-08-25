using BookManagement.Core.DTOs.BookDTOs;
using FluentValidation;

namespace BookManagement.Services.Helpers.Validators;

public class BookPropertiesDTOValidator : AbstractValidator<BookPropertiesDTO>
{
    public BookPropertiesDTOValidator()
    {
        RuleFor(t => t.PublishDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Publish date cannot be in the future.");
    }
}