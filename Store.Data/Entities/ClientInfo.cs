using System.Collections.Generic;

namespace Store.Data.Entities;

public class ClientInfo : BaseEntity
{
    public string LastName { get; set; } // Фамилия

    public string FirstName { get; set; } // Имя

    public string Patronymic { get; set; } // Отчество

    public string PhoneNumber { get; set; } // Номер телефона

    public string Email { get; set; } // Электронная почта

    public ICollection<ClientOrder> Orders { get; set; }
}