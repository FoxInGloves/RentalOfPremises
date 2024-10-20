using RentalOfPremises.Models.Abstractions;

namespace RentalOfPremises.Models.Implementation;

public class Premise : Entity
{
    /*public string ClientId { get; set; }*/
    
    /*public string ContractId { get; set; }*/
    
    public string Name { get; set; }
    
    public string Area { get; set; }
    
    public string BackgroundColor { get; set; }
    
    /*public virtual Client Client { get; set; }
    
    public virtual Contract Contract { get; set; }*/
}