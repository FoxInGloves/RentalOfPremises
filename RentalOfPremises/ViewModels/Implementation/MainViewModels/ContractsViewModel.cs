using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using RentalOfPremises.Models.Data;
using RentalOfPremises.Repository.Implementation;
using RentalOfPremises.Services.Command;
using RentalOfPremises.ViewModels.Abstraction;
using RentalOfPremises.ViewModels.Implementation.AdditionalViewModels;
using RentalOfPremises.Views.AdditionalViews;

namespace RentalOfPremises.ViewModels.Implementation.MainViewModels;

public sealed class ContractsViewModel : BaseViewModel
{
    private readonly RentalRepository _repository;
    
    private ObservableCollection<RentalData> _collection;

    private RentalData? _selectedItem;

    private readonly ICommand _deleteContractCommand;
    
    private readonly ICommand _addNewContractCommand;
    
    public ContractsViewModel()
    {
        _repository = new RentalRepository();
        
        _collection = new ObservableCollection<RentalData>(_repository.Read().Where(x => x.Contract != "---"));

        _deleteContractCommand = new RelayCommand(_ => DeleteContract(), _ => true);

        _addNewContractCommand = new RelayCommand(_ => AddNewContract(), _ => true);
    }

    public ObservableCollection<RentalData> Collection => _collection;

    public RentalData? SelectedItem
    {
        get => _selectedItem;

        set => SetField(ref _selectedItem, value);
    }

    public ICommand DeleteContractCommand => _deleteContractCommand;
    
    public ICommand AddNewContractCommand => _addNewContractCommand;

    private void DeleteContract()
    {
        if (_selectedItem == null)
            MessageBox.Show("Выберите договор");

        _collection.Remove(_selectedItem);
        
        _repository.Delete(_selectedItem.NamePremise);
    }

    private void AddNewContract()
    {
        var data = GetData();

        if (data is null)
            return;
        
        _collection.Add(data);
        _repository.Update(data);
    }
    
    private RentalData? GetData()
    {
        var addContractWindow = new AddNewContractWindow();

        var addContractViewModel = new AddNewContractViewModel();

        addContractWindow.DataContext = addContractViewModel;

        var dialog = addContractWindow.ShowDialog();

        if (dialog is not true)
            return null;
        
        var data = new RentalData(addContractViewModel.NamePremise, "---", addContractViewModel.ContractNumber,
            addContractViewModel.Client, addContractViewModel.Price + addContractViewModel.SelectedCurrency, 
            addContractViewModel.StartDate, addContractViewModel.EndDate, "#FF4040");

        _collection.Add(data);
        return data;
    }
} 