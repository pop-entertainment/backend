using FluentValidation;
using Store.Application.DTOs.OrderItem;

namespace Store.Application.Validators;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemValidator()
    {
        // Проверка количества товара
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Количество товара должно быть больше 0");

        // Проверка, что товар указан
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Товар не может быть пустым");
    }
}