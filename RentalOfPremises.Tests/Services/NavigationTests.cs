using  Moq;
using RentalOfPremises.Repository.Abstraction;
using RentalOfPremises.Services.Navigation.Abstractions;
using RentalOfPremises.Services.Navigation.Implementations;
using RentalOfPremises.ViewModels.Abstraction;
using RentalOfPremises.ViewModels.Implementation.AdditionalViewModels;
using RentalOfPremises.ViewModels.Implementation.MainViewModels;
using RentalOfPremises.Views.AdditionalViews;
using RentalOfPremises.Views.MainViews;

namespace Tests.Services;

public class NavigationTests
{
    [StaFact]
    public void NavigateToPage_AboutVM_ReturnsAboutPage()
    {
        var navigationService = new NavigationService();
        var viewModel = new AboutViewModel();

        var viewAndViewModel = navigationService.NavigateToPage(viewModel);
        
        Assert.IsType<AboutPage>(viewAndViewModel.Item1);
    }

    [StaFact]
    public void NavigateToPage_ClientsVM_ReturnsClientsPage()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var navigationService = new NavigationService();
        var clientsViewModel = new ClientsViewModel(mockUnitOfWork.Object);
        
        var viewAndViewModel = navigationService.NavigateToPage(clientsViewModel);
        
        Assert.IsType<ClientsPage>(viewAndViewModel.Item1);
    }

    [StaFact]
    public void NavigateToPage_ContractsVM_ReturnsContractsPage()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var navigationService = new NavigationService();
        var contractsViewModel = new ContractsViewModel(mockUnitOfWork.Object, navigationService);
        
        var viewAndViewModel = navigationService.NavigateToPage(contractsViewModel);
        
        Assert.IsType<ContractsPage>(viewAndViewModel.Item1);
    }

    [StaFact]
    public void NavigateToPage_PremisesVM_ReturnsPremisesPage()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var navigationService = new NavigationService();
        var premisesViewModel = new PremisesViewModel(mockUnitOfWork.Object);
        
        var viewAndViewModel = navigationService.NavigateToPage(premisesViewModel);
        
        Assert.IsType<PremisesPage>(viewAndViewModel.Item1);
    }

    [StaFact]
    public void NavigateToPage_MockViewModel_ArgumentNullException()
    {
        var mockBaseViewModel = new Mock<BaseViewModel>();
        var navigationService = new NavigationService();
        
        Assert.Throws<ArgumentNullException>(() => navigationService.NavigateToPage(mockBaseViewModel.Object));
    }

    [StaFact]
    public void NavigateToWindow_AddNewContractVM_ReturnsAddNewContractWindow()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var navigationService = new NavigationService();
        var addNewContractViewMadel = new AddNewContractViewModel(mockUnitOfWork.Object);
        
        var viewAndViewModel = navigationService.NavigateToWindow(addNewContractViewMadel);
        
        Assert.IsType<AddNewContractWindow>(viewAndViewModel.Item1);
    }

    [StaFact]
    public void NavigateToWindow_AddNewPremiseVM_ReturnsAddNewPremiseWindow()
    {
        var navigationService = new NavigationService();
        var addNewPremiseViewMadel = new AddNewPremiseViewModel();
        
        var viewAndViewModel = navigationService.NavigateToWindow(addNewPremiseViewMadel);
        
        Assert.IsType<AddNewPremiseWindow>(viewAndViewModel.Item1);
    }
}