using System.ComponentModel.DataAnnotations;

namespace RentalOfPremises.Models.Data;

public record RentalData
{
    private string _namePremise;

    private string _premiseFacility;
    
    private string _contract;

    private string _client;
    
    private string _price;
    
    private string _startDate;
    
    private string _endDate;

    private string _background;

    public RentalData(string namePremise, string areaPremise, string contract, 
        string client, string price, string startDate, string endDate, string background)
    {
        NamePremise = namePremise;
        AreaPremise = areaPremise;
        Contract = contract;
        Client = client;
        Price = price;
        StartDate = startDate;
        EndDate = endDate;
        Background = background;
    }

    [Key]
    public string NamePremise
    {
        get => _namePremise;
        
        set => _namePremise = value;
    }

    public string AreaPremise
    {
        get => _premiseFacility;
        
        set => _premiseFacility = value;
    }

    public string Contract
    {
        get => _contract;
        
        set => _contract = value;
    }

    public string Client
    {
        get => _client;
        
        set => _client = value;
    }

    public string Price
    {
        get => _price;
        
        set => _price = value;
    }

    public string StartDate
    {
        get => _startDate;
        
        set => _startDate = value;
    }

    public string EndDate
    {
        get => _endDate;
        
        set => _endDate = value;
    }

    public string Background
    {
        get => _background;

        set => _background = value;
    }
}