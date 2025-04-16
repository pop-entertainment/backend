using FluentValidation;
using Store.Application.DTOs.SubCategory;

namespace Store.Application.Validators;

public class CreateSubCategoryValidator : AbstractValidator<CreateSubCategoryDto>
{
    public CreateSubCategoryValidator()
    {
        RuleFor(x => x.SubCategoryName)
            .NotEmpty().WithMessage("Название подкатегории не может быть пустым")
            .MaximumLength(150).WithMessage("Название подкатегории должно содержать не более 150 символов");

        RuleFor(x => x.ImagePath)
            .NotEmpty().WithMessage("Путь к изображению обязателен")
            .Must(BeAValidUrl).WithMessage("Некорректный URL изображения");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Id категории не может быть пустым");
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}