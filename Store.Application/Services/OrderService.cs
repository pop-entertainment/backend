using AutoMapper;
using Store.Application.DTOs.Order;
using Store.Application.DTOs.OrderItem;
using Store.Application.Interfaces;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderItemsRepository _orderItemsRepository;
    private readonly IClientOrdersRepository _clientOrdersRepository;
    private readonly IProductInfosRepository _productInfosRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IOrderItemsRepository orderItemsRepository, IClientOrdersRepository clientOrdersRepository, IMapper mapper, IUnitOfWork unitOfWork, IProductInfosRepository productInfosRepository)
    {
        _orderItemsRepository = orderItemsRepository;
        _clientOrdersRepository = clientOrdersRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _productInfosRepository = productInfosRepository;
    }
    
    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken)
    {
        var orders = await _clientOrdersRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }
    
    public async Task<OrderDto> GetOrderAsync(Guid id, CancellationToken cancellationToken)
    {
        var orders = await _clientOrdersRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<OrderDto>(orders);
    }

    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        decimal totalAmount = 0;

        var order = new ClientOrder
        {
            ClientPhone = orderDto.ClientPhone,
            OrderDate = DateTime.UtcNow,
            OrderItems = new List<OrderItem>()
        };

        _clientOrdersRepository.Add(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        foreach (var item in orderDto.OrderItems)
        {
            var product = await _productInfosRepository.GetAsync(item.ProductId, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            var price = product.Price * (1 - product.Discount / 100);

            var orderItem = new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = price,
                ClientOrderId = order.Id
            };

            totalAmount += item.Quantity * price;
            _orderItemsRepository.Add(orderItem);
        }

        order.TotalAmount = totalAmount;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<IEnumerable<OrderItemDto>> GetAllItemAsync(CancellationToken cancellationToken)
    {
        var orderItems = await _orderItemsRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
    }

    public async Task<OrderItemDto> GetItemAsync(Guid id, CancellationToken cancellationToken)
    {
        var orderItems = await _orderItemsRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<OrderItemDto>(orderItems);
    }
}