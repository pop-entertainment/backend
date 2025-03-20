using System.Collections.Generic;
using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class ClientInfo : BaseEntity
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set;}
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; set;}
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set;}

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set;}

    public ICollection<ClientOrder> Orders { get; set; }
}