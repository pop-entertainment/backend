namespace Store.Application.DTOs.Order;

public class OrderDto
{
    public Guid Id { get; set; }
    public string ClientPhone { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItem.OrderItemDto> OrderItems { get; set; }
}