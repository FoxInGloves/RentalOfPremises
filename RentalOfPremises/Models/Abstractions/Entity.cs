using System;
using System.ComponentModel.DataAnnotations;

namespace RentalOfPremises.Models.Abstractions;

public class Entity
{
    [Key]
    public virtual Guid Id { get; } = Guid.NewGuid();
}