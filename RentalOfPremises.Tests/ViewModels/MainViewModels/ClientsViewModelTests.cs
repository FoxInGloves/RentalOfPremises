using Moq;
using RentalOfPremises.Models.Implementation;
using RentalOfPremises.Repository.Abstraction;
using RentalOfPremises.ViewModels.Implementation.MainViewModels;

namespace Tests.ViewModels.MainViewModels;

public class ClientsViewModelTests
{
    [Fact]
    public async Task UpdateAsync_CollectionOfClientsNotNull()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.ClientsRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Client(),
                new Client()
            ]);
        var clientsViewModel = new ClientsViewModel(mockUnitOfWork.Object);

        await clientsViewModel.UpdateAsync();

        Assert.NotNull(clientsViewModel.CollectionOfClients);
    }
}