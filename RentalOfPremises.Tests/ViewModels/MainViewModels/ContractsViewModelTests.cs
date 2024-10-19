using System.Diagnostics;
using Moq;
using RentalOfPremises.Models.Implementation;
using RentalOfPremises.Repository.Abstraction;
using RentalOfPremises.Services.Navigation.Implementations;
using RentalOfPremises.ViewModels.Implementation.MainViewModels;

namespace Tests.ViewModels.MainViewModels;

public class ContractsViewModelTests
{
    [Fact]
    public async Task UpdateAsync_CollectionOfContractsNotNull()
    {
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
        var contractsViewModel = new ContractsViewModel(mockUnitOfWork.Object, new NavigationService());

        await contractsViewModel.UpdateAsync();

        Assert.NotNull(contractsViewModel.CollectionOfContracts);
    }
    
    [Fact]
    public async Task UpdateAsync_CollectionOfClientsNotNull()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client()
            ]);
        mockUnitOfWork.Setup(x => x.ContractsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Contract()
            ]);
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        var contractsViewModel = new ContractsViewModel(mockUnitOfWork.Object, new NavigationService());

        await contractsViewModel.UpdateAsync();

        Assert.NotNull(contractsViewModel.CollectionOfClients);
    }
    
    [Fact]
    public async Task UpdateAsync_CollectionOfPremisesNotNull()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        mockUnitOfWork.Setup(x => x.ContractsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Contract()
            ]);
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client()
            ]);
        var contractsViewModel = new ContractsViewModel(mockUnitOfWork.Object, new NavigationService());

        await contractsViewModel.UpdateAsync();

        Assert.NotNull(contractsViewModel.CollectionOfPremises);
    }

    [Fact]
    public async Task DeleteContract_SelectedContractNotNull_CollectionWithoutThisContract()
    {
        var contractsInDataBase = new[] { new Contract(), new Contract(), new Contract() };
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.ContractsRepository.GetAsync(null, null))
            .ReturnsAsync(contractsInDataBase);
        mockUnitOfWork.Setup(x => x.ContractsRepository.DeleteAsync(contractsInDataBase[0].Id.ToString()));
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client()
            ]);
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        var contractsViewModel = new ContractsViewModel(mockUnitOfWork.Object, new NavigationService());
        await contractsViewModel.UpdateAsync();
        Debug.Assert(contractsViewModel.CollectionOfContracts != null, "contractsViewModel.CollectionOfContracts != null");
        contractsViewModel.SelectedContract = contractsViewModel.CollectionOfContracts[0];

        contractsViewModel.DeleteContractAsyncCommand.Execute(null);
        
        Assert.Empty(contractsViewModel.CollectionOfContracts.Where(k => k.Id == contractsInDataBase[0].Id));
    }
    
    [Fact]
    public async Task DeleteContract_SelectedContractIsNull_CollectionWithoutThisContract()
    {
        var contractsInDataBase = new[] { new Contract(), new Contract(), new Contract() };
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.ContractsRepository.GetAsync(null, null))
            .ReturnsAsync(contractsInDataBase);
        mockUnitOfWork.Setup(x => x.ContractsRepository.DeleteAsync(contractsInDataBase[0].Id.ToString()));
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client()
            ]);
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        var contractsViewModel = new ContractsViewModel(mockUnitOfWork.Object, new NavigationService());
        await contractsViewModel.UpdateAsync();
        
        contractsViewModel.DeleteContractAsyncCommand.Execute(null);

        Debug.Assert(contractsViewModel.CollectionOfContracts != null, "contractsViewModel.CollectionOfContracts != null");
        Assert.NotEmpty(contractsViewModel.CollectionOfContracts.Where(x => x.Id == contractsInDataBase[0].Id));
    }
    
    /*[StaFact]
    public async Task AddNewContract_CollectionWithNewContract()
    {
        var newContract = new Contract();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.ContractsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Contract()
            ]);
        mockUnitOfWork.Setup(x => x.ContractsRepository.CreateAsync(newContract));
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client()
            ]);
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        var contractsViewModel = new ContractsViewModel(mockUnitOfWork.Object, new NavigationService());
        await contractsViewModel.UpdateAsync();
        contractsViewModel.SelectedContract = newContract;

        contractsViewModel.AddNewContractAsyncCommand.Execute(null);

        Assert.NotEmpty(contractsViewModel.CollectionOfContracts.Where(x => x.Id == newContract.Id));
    }*/
}