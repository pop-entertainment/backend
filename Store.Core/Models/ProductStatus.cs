namespace Store.Core.Models;

public enum ProductStatus
{
    OutStock = 0, // Нет в наличии
    InStock = 1, // В наличии в городе
    ToOrder = 2 // На заказ
}