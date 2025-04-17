using AutoMapper;
using Moq;
using Store.Application.DTOs.Order;
using Store.Application.DTOs.OrderItem;
using Store.Application.Interfaces;
using Store.Application.Repositories;
using Store.Application.Services;
using Store.Domain.Entities;
using Xunit;

namespace Store.Test;

public class CreateOrderTest
{
    private readonly Mock<IOrderItemsRepository> _orderItemsRepoMock = new();
    private readonly Mock<IClientOrdersRepository> _clientOrdersRepoMock = new();
    private readonly Mock<IProductInfosRepository> _productInfosRepoMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly IMapper _mapper;

    public CreateOrderTest()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ClientOrder, OrderDto>();
        });
        _mapper = config.CreateMapper();
    }
    
    [Fact]
    public async Task CreateOrderAsync_CreatesOrderSuccessfully()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var createOrderDto = new CreateOrderDto
        {
            ClientPhone = "79141094006",
            OrderItems = new List<CreateOrderItemDto>
            {
                new CreateOrderItemDto
                {
                    ProductId = productId,
                    Quantity = 2
                }
            }
        };

        var product = new ProductInfo
        {
            Id = productId,
            Title = "Тест",
            Price = 100,
            Discount = 10
        };

        _productInfosRepoMock.Setup(repo => repo.GetAsync(productId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product);

        var orderService = new OrderService(
            _orderItemsRepoMock.Object,
            _clientOrdersRepoMock.Object,
            _mapper,
            _unitOfWorkMock.Object,
            _productInfosRepoMock.Object
        );

        // Act
        var result = await orderService.CreateOrderAsync(createOrderDto, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        _clientOrdersRepoMock.Verify(repo => repo.Add(It.IsAny<ClientOrder>()), Times.Once);
        _orderItemsRepoMock.Verify(repo => repo.Add(It.IsAny<OrderItem>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
    }
}