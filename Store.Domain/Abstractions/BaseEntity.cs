using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Abstractions;

public abstract class BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public DateTime ModifiedOn { get; set; }
}