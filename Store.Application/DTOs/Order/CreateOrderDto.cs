using Store.Application.DTOs.OrderItem;

namespace Store.Application.DTOs.Order;

public class CreateOrderDto
{
    public string ClientPhone { get; set; }
    public List<CreateOrderItemDto> OrderItems { get; set; }
}