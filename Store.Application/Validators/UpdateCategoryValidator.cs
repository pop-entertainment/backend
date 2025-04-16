using FluentValidation;
using Store.Application.DTOs.Category;

namespace Store.Application.Validators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Название категории не может быть пустым")
            .MaximumLength(150).WithMessage("Название категории должно содержать не более 150 символов");

        RuleFor(x => x.ImagePath)
            .NotEmpty().WithMessage("Путь к изображению обязателен")
            .Must(BeAValidUrl).WithMessage("Некорректный URL изображения");
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}