using System.Collections.Generic;
using System.Linq;
using RentalOfPremises.Models.Data;
using RentalOfPremises.Repository.Implementation;
using RentalOfPremises.ViewModels.Abstraction;

namespace RentalOfPremises.ViewModels.Implementation.MainViewModels;

public class ClientsViewModel : BaseViewModel
{
    private IEnumerable<RentalData>? _collectionOfClients;

    private readonly RentalRepository _repository;
    
    public ClientsViewModel()
    {
        _repository = new RentalRepository();
    }

    public IEnumerable<RentalData>? CollectionOfClients => _collectionOfClients;

    public override void Update()
    {
        _collectionOfClients = _repository.Read().Where(x => x.Contract != "---");
    }
}