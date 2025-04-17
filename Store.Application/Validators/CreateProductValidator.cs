using FluentValidation;
using Store.Application.DTOs.Product;

namespace Store.Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        // Проверка названия товара
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Название товара не может быть пустым")
            .MaximumLength(200).WithMessage("Название товара должно содержать не более 200 символов");

        // Проверка цены товара
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Цена товара должна быть больше 0");

        // Проверка описания товара
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Описание товара не может быть пустым")
            .MaximumLength(1000).WithMessage("Описание товара должно содержать не более 1000 символов");

        // Проверка скидки
        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Скидка не может быть отрицательной")
            .LessThanOrEqualTo(100).WithMessage("Скидка не может превышать 100%");

        // Проверка пути к изображению
        RuleFor(x => x.ImagePath)
            .NotEmpty().WithMessage("Путь к изображению товара обязателен")
            .Must(BeAValidUrl).WithMessage("Некорректный URL изображения");

        // Проверка категории товара
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Id категории товара не может быть пустым");
    }
    
    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}