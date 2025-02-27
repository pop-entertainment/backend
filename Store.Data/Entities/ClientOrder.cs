using System;
using System.Collections.Generic;

namespace Store.Data.Entities;

public class ClientOrder : BaseEntity
{
    // Клиент, сделавший заказ
    public Guid ClientId { get; set; }
    public ClientInfo Client { get; set; }

    // Дата оформления заказа
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    // Общая сумма заказа
    public decimal TotalAmount { get; set; }

    // Список товаров в заказе
    public ICollection<OrderItem> OrderItems { get; set; }
}