using Store.Application.DTOs.Order;
using Store.Application.DTOs.OrderItem;

namespace Store.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken);
    Task<OrderDto> GetOrderAsync(Guid id, CancellationToken cancellationToken);
    Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken);
    Task<IEnumerable<OrderItemDto>> GetAllItemAsync(CancellationToken cancellationToken);
    Task<OrderItemDto> GetItemAsync(Guid id, CancellationToken cancellationToken);
}