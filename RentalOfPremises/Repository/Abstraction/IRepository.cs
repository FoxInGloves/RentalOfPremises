using System.Collections.Generic;
using RentalOfPremises.Models.Data;

namespace RentalOfPremises.Repository.Abstraction;

public interface IRepository
{
    void Add(RentalData rentalData);
    
    IList<RentalData> Read();

    void Update(RentalData rentalData);

    void Delete(string namePremise);
}