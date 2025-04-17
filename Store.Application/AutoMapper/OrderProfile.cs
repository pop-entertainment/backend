using AutoMapper;
using Store.Application.DTOs.Order;
using Store.Application.DTOs.OrderItem;
using Store.Domain.Entities;

namespace Store.Application.AutoMapper;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<ClientOrder, OrderDto>().ReverseMap();
        CreateMap<CreateOrderDto, OrderDto>().ReverseMap();

        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<CreateOrderItemDto, OrderItem>().ReverseMap();
    }
}