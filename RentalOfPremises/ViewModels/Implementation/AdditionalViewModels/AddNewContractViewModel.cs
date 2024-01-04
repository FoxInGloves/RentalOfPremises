using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using RentalOfPremises.Repository.Implementation;
using RentalOfPremises.Services.Command;
using RentalOfPremises.ViewModels.Abstraction;

namespace RentalOfPremises.ViewModels.Implementation.AdditionalViewModels;

public class AddNewContractViewModel : BaseViewModel
{
    private string _contractNumber;

    private string _namePremise;

    private string _client;

    private string _price;
    
    private readonly IList<string> _currencyList;

    private string _selectedCurrency;

    private string _startDate;

    private string _endDate;

    private readonly ICommand _saveCommand;
    
    private readonly ICommand _cancelCommand;
    
    private IEnumerable<string> _collection;
    
    public AddNewContractViewModel()
    {
        _currencyList = new List<string>() { "Rybl`" };

        _selectedCurrency = _currencyList.First();

        var repository = new RentalRepository();
        Collection = repository.Read().Where(y => y.Background == "#00FF7F").Select(x => x.NamePremise);
        
        SaveCommand = new RelayCommand(window =>
            CloseWindow((Window)window, true), _ => true);

        CancelCommand = new RelayCommand(window =>
            CloseWindow((Window)window, false), _ => true);
    }

    public string ContractNumber
    {
        get => _contractNumber;

        set => SetField(ref _contractNumber, value);
    }

    public string NamePremise
    {
        get => _namePremise;

        init => SetField(ref _namePremise, value);
    }

    public string Client
    {
        get => _client;

        set => SetField(ref _client, value);
    }

    public string Price
    {
        get => _price;

        set => SetField(ref _price, value);
    }

    public IList<string> CurrencyList => _currencyList;

    public string SelectedCurrency
    {
        get => _selectedCurrency;

        set => SetField(ref _selectedCurrency, value);
    }

    public string StartDate
    {
        get => _startDate;

        set => SetField(ref _startDate, value);
    }

    public string EndDate
    {
        get => _endDate;

        set => SetField(ref _endDate, value);
    }
    
    public ICommand SaveCommand
    {
        get => _saveCommand;

        init => SetField(ref _saveCommand, value);
    }

    public ICommand CancelCommand
    {
        get => _cancelCommand;

        init => SetField(ref _cancelCommand, value);
    }

    public IEnumerable<string> Collection
    {
        get => _collection;

        init => SetField(ref _collection, value);
    }
    
    private void CloseWindow(Window window, bool dialogResult)
    {
        if (dialogResult is false)
        {
            window.Close();
            return;
        }
            
//TODO дописать условие
        if (!string.IsNullOrWhiteSpace(ContractNumber) && !string.IsNullOrWhiteSpace(NamePremise) &&
            !string.IsNullOrWhiteSpace(Client) && !string.IsNullOrWhiteSpace(Price))
        {
            window.DialogResult = true;
            return;
        }

        MessageBox.Show("Одно из полей незаполнено");
    }
}