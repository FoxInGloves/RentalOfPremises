using System;
using RentalOfPremises.Models.Abstractions;

namespace RentalOfPremises.Models.Implementation;

public class Client : Entity
{
    public override Guid Id { get; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}