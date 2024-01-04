using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using RentalOfPremises.Services.Command;
using RentalOfPremises.ViewModels.Abstraction;

namespace RentalOfPremises.ViewModels.Implementation.AdditionalViewModels;

public sealed class AddNewPremiseViewModel : BaseViewModel
{
    private string _namePremise;

    private string _areaPremise;

    private readonly IList<string> _unitList;

    private string _selectedUnit;
    
    private readonly ICommand _saveCommand;

    private readonly ICommand _cancelCommand;

    public AddNewPremiseViewModel()
    {
        _unitList = new List<string>() { "m\u00b2" };

        _selectedUnit = _unitList.First();
        
        SaveCommand = new RelayCommand(window =>
            CloseWindow((Window)window, true), _ => true);

        CancelCommand = new RelayCommand(window =>
            CloseWindow((Window)window, false), _ => true);
    }

    public string NamePremise
    {
        get => _namePremise;

        set => SetField(ref _namePremise, value);
    }

    public string AreaPremise
    {
        get => _areaPremise;

        set => SetField(ref _areaPremise, value);
    }

    public IList<string> UnitList => _unitList;

    public string SelectedUnit
    {
        get => _selectedUnit;

        set => SetField(ref _selectedUnit, value);
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

    private void CloseWindow(Window window, bool dialogResult)
    {
        if (dialogResult is false)
        {
            window.Close();
            return;
        }
            

        if (!string.IsNullOrWhiteSpace(NamePremise) && !string.IsNullOrWhiteSpace(AreaPremise))
        {
            window.DialogResult = true;
            return;
        }

        MessageBox.Show("Одно из полей незаполнено");
    }
}