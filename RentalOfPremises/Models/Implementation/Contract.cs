using RentalOfPremises.Models.Abstractions;

namespace RentalOfPremises.Models.Implementation;

public class Contract : Entity
{
    public string Number { get; set; }
    
    public string Prise { get; set; }
    
    public string PremiseId { get; set; }
    
    public string ClientId { get; set; }
    
    public string StartDate { get; set; }
    
    public string EndDate { get; set; }
    
    public virtual Premise Premise { get; set; }
    
    public virtual Client Client { get; set; }
}