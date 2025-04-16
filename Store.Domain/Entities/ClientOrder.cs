using System;
using System.Collections.Generic;
using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class ClientOrder : BaseEntity
{
    // /// <summary>
    // /// Клиент, сделавший заказ
    // /// </summary>
    // public Guid ClientId { get; set; }
    // public ClientInfo Client { get; set; }
    
    /// <summary>
    /// Номер телефона клиента сделавшего заказ
    /// </summary>
    public string ClientPhone { get; set; }
    
    /// <summary>
    /// Дата оформления заказа
    /// </summary>
    public DateTime OrderDate { get; set; }
    
    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public decimal TotalAmount { get; set; }
    
    /// <summary>
    /// Список товаров в заказе
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; }
}