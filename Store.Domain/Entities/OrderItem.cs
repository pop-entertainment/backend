using System;
using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class OrderItem : BaseEntity
{
    /// <summary>
    /// Связь с заказом
    /// </summary>
    public Guid ClientOrderId { get; set; }
    public ClientOrder ClientOrder { get; set; }
    
    /// <summary>
    /// Связь с товаром
    /// </summary>
    public Guid ProductId { get; set; }
    public ProductInfo Product { get; set; }
    
    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Цена товара в момент заказа
    /// </summary>
    public decimal Price { get; set; }
}