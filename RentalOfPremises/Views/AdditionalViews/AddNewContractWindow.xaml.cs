using System.Windows;
using RentalOfPremises.ViewModels.Implementation.AdditionalViewModels;

namespace RentalOfPremises.Views.AdditionalViews;

public partial class AddNewContractWindow : Window
{
    public AddNewContractWindow()
    {
        InitializeComponent();

        DataContext = new AddNewContractViewModel();
    }
}