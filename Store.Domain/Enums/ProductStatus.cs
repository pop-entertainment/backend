namespace Store.Domain.Enums;

public enum ProductStatus
{
    /// <summary>
    /// Нет в наличии
    /// </summary>
    OutStock = 0,
    /// <summary>
    /// В наличии в городе
    /// </summary>
    InStock = 1,
    /// <summary>
    /// На заказ
    /// </summary>
    ToOrder = 2
}