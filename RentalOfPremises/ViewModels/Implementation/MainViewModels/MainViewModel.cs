using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using RentalOfPremises.Services.Command;
using RentalOfPremises.Services.Navigation;
using RentalOfPremises.ViewModels.Abstraction;

namespace RentalOfPremises.ViewModels.Implementation.MainViewModels;

public sealed class MainViewModel : BaseViewModel
{
    private Page _currentPage;

    private readonly NavigationService _navigationService;

    private (Page, BaseViewModel)? _facilityPage;

    private (Page, BaseViewModel)? _contractsPage;

    private (Page, BaseViewModel)? _clientsPage;
    
    private (Page, BaseViewModel)? _aboutPage;

    private readonly ICommand _navigateToPremisesPageCommand;

    private readonly ICommand _navigateToContractsPage;

    private readonly ICommand _navigateToClientsPageCommand;
    
    private readonly ICommand _navigateToAboutPageCommand;

    private readonly ICommand _openHelp;

    public MainViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;

        //TODO: сделать выбор стартовой страницы
        _currentPage = NavigateToPremisePage().Item1;

        _navigateToPremisesPageCommand = new RelayCommand( _ =>
            CurrentPage = NavigateToPremisePage().Item1, _ => true);

        _navigateToContractsPage = new RelayCommand(_ =>
            CurrentPage = NavigateToContractsPage().Item1, _ => true);

        _navigateToClientsPageCommand = new RelayCommand(_ =>
            CurrentPage = NavigateToClientsPage().Item1, _ => true);
        
        _navigateToAboutPageCommand = new RelayCommand(_ =>
            CurrentPage = NavigateToAboutPage().Item1, _ => true);

        _openHelp = new RelayCommand(_ => OpenHelp(), _ => true);
    }

    public Page CurrentPage
    {
        get => _currentPage;

        set => SetField(ref _currentPage, value);
    }

    public ICommand NavigateToPremisesPageCommand => _navigateToPremisesPageCommand;

    public ICommand NavigateToContractsPageCommand => _navigateToContractsPage;

    public ICommand NavigateToClientsPageCommand => _navigateToClientsPageCommand;
    
    public ICommand NavigateToAboutPageCommand => _navigateToAboutPageCommand;

    public ICommand OpenHelpCommand => _openHelp;

    private (Page, BaseViewModel) NavigateToPremisePage()
    {
        var pageAndVm = _facilityPage ??= _navigationService.Navigate(new PremisesViewModel());
        
        pageAndVm.Item2.Update();

        return pageAndVm;
    }

    private (Page, BaseViewModel) NavigateToContractsPage()
    {
        return _contractsPage ??= _navigationService.Navigate(new ContractsViewModel());
    }

    private (Page, BaseViewModel) NavigateToClientsPage()
    {
        var pageAndVm = _clientsPage ??= _navigationService.Navigate(new ClientsViewModel());
        
        pageAndVm.Item2.Update();

        return pageAndVm;
    }

    private (Page, BaseViewModel) NavigateToAboutPage()
    {
        return _aboutPage ??= _navigationService.Navigate(new AboutViewModel());
    }

    private void OpenHelp()
    {
        var uriString = AppDomain.CurrentDomain.BaseDirectory + "Resources\\Help\\Help.chm";

        Process.Start(new ProcessStartInfo(uriString) { UseShellExecute = true });
    }
}