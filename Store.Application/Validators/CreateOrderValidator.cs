using FluentValidation;
using Store.Application.DTOs.Order;

namespace Store.Application.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    { 
        // Проверка номера телефона клиента
        RuleFor(x => x.ClientPhone)
            .NotEmpty().WithMessage("Номер телефона клиента не может быть пустым")
            .Matches(@"^7\d{10}$").WithMessage("Некорректный формат номера телефона");

        // Проверка наличия товаров в заказе
        RuleFor(x => x.OrderItems)
            .NotEmpty().WithMessage("Список товаров в заказе не может быть пустым");
    }
}