using Moq;
using RentalOfPremises.Models.Implementation;
using RentalOfPremises.Repository.Abstraction;
using RentalOfPremises.Services.Navigation.Implementations;
using RentalOfPremises.ViewModels.Implementation.MainViewModels;
using RentalOfPremises.Views.MainViews;

namespace Tests.ViewModels.MainViewModels;

public class MainViewModelTests
{
    [StaFact]
    public void MainViewModelConstructor_CurrentPageIsDefault()
    {
        var navigationService = new NavigationService();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        
        var mainViewModel = new MainViewModel(navigationService, mockUnitOfWork.Object);
        
        Assert.IsType<PremisesPage>(mainViewModel.CurrentPage);
    }
    
    [StaFact]
    public void NavigateToPremisesPageCommand_CurrentPageIsPremisesPage()
    {
        var navigationService = new NavigationService();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        var mainViewModel = new MainViewModel(navigationService, mockUnitOfWork.Object);
        mainViewModel.NavigateToClientsPageCommand.Execute(null);
        
        mainViewModel.NavigateToPremisesPageCommand.Execute(null);
        
        
        //! Не уверен что без ожидания страница загружается правильно TODO Убрать когда приложение будет доделано
        //await Task.Delay(1000);
        
        Assert.IsType<PremisesPage>(mainViewModel.CurrentPage);
    }

    [StaFact]
    public void NavigateToContractsPageCommand_CurrentPageIsContractsPage()
    {
        var navigationService = new NavigationService();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.ContractsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Contract()
            ]);
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client()
            ]);
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        var mainViewModel = new MainViewModel(navigationService, mockUnitOfWork.Object);
        
        mainViewModel.NavigateToContractsPageCommand.Execute(null);
        
        Assert.IsType<ContractsPage>(mainViewModel.CurrentPage);
    }

    [StaFact]
    public void NavigateToClientsPageCommand_CurrentPageIsClientsPage()
    {
        var navigationService = new NavigationService();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client()
            ]);
        var mainViewModel = new MainViewModel(navigationService, mockUnitOfWork.Object);
        
        mainViewModel.NavigateToClientsPageCommand.Execute(null);
        
        Assert.IsType<ClientsPage>(mainViewModel.CurrentPage);
    }

    [StaFact]
    public void NavigateToAboutPageCommand_CurrentPageIsAboutPage()
    {
        var navigationService = new NavigationService();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mainViewModel = new MainViewModel(navigationService, mockUnitOfWork.Object);
        
        mainViewModel.NavigateToAboutPageCommand.Execute(null);
        
        Assert.IsType<AboutPage>(mainViewModel.CurrentPage);
    }
}