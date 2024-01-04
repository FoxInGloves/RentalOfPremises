using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RentalOfPremises.Models.Data;
using RentalOfPremises.Repository.Implementation;
using RentalOfPremises.Services.Command;
using RentalOfPremises.ViewModels.Abstraction;
using RentalOfPremises.ViewModels.Implementation.AdditionalViewModels;
using RentalOfPremises.Views.AdditionalViews;

namespace RentalOfPremises.ViewModels.Implementation.MainViewModels;

public sealed class PremisesViewModel : BaseViewModel
{
    private readonly RentalRepository _repository;
    
    private ObservableCollection<RentalData> _collection;

    private readonly ICommand _addPremiseCommand;

    private readonly ICommand _deletePremiseCommand;

    public PremisesViewModel()
    {
        _repository = new RentalRepository();
        
        _collection = new ObservableCollection<RentalData>(_repository.Read());

        _addPremiseCommand = new RelayCommand(_ => AddPremise(), _ => true);

        _deletePremiseCommand = new RelayCommand(data => DeletePremise((string)data), _ => true);
    }

    public ObservableCollection<RentalData> Collection => _collection;

    public ICommand AddPremiseCommand => _addPremiseCommand;

    public ICommand DeletePremiseCommand => _deletePremiseCommand;

    private void AddPremise()
    {
        var data = GetData();
        
        if(data is null)
            return;
        
        _collection.Add(data);
        
        _repository.Add(data);
    }

    private RentalData? GetData()
    {
        var addPremiseWindow = new AddNewPremiseWindow();

        var addPremiseViewModel = new AddNewPremiseViewModel();

        addPremiseWindow.DataContext = addPremiseViewModel;

        var dialog = addPremiseWindow.ShowDialog();

        if (dialog is not true)
            return null;

        return new RentalData(addPremiseViewModel.NamePremise, addPremiseViewModel.AreaPremise + addPremiseViewModel.SelectedUnit, 
            "---", "---", "---", "---", "---", "#00FF7F");
    }

    private void DeletePremise(string data)
    {
        var rentalData = _collection.First(x => x.NamePremise == data);

        _collection.Remove(rentalData);

        _repository.Delete(data);
    }
    
    public override void Update()
    {
        _collection = new ObservableCollection<RentalData>(_repository.Read());
    }
}