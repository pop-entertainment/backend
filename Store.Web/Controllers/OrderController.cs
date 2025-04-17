using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Order;
using Store.Application.Interfaces;

namespace Store.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet("GetAllOrders")]
    public async Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var orders = await _orderService.GetAllOrdersAsync(cancellationToken);
        return orders;
    }

    [HttpGet("{id}")]
    public async Task<OrderDto> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await _orderService.GetOrderAsync(id, cancellationToken);
        return order;
    }

    [HttpPost("CreateOrder")]
    public async Task<OrderDto> CreateOrderAsync([FromBody] CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        var order = await _orderService.CreateOrderAsync(orderDto, cancellationToken);
        return order;
    }
}