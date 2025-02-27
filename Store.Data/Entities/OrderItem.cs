using System;

namespace Store.Data.Entities;

public class OrderItem : BaseEntity
{
    // Связь с заказом
    public Guid ClientOrderId { get; set; }
    public ClientOrder ClientOrder { get; set; }

    // Связь с товаром
    public Guid ProductId { get; set; }
    public ProductInfo Product { get; set; }

    // Количество товара
    public int Quantity { get; set; }

    // Цена товара в момент заказа
    public decimal Price { get; set; }
}