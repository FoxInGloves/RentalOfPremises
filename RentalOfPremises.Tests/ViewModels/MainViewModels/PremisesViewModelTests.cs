using Moq;
using RentalOfPremises.Models.Implementation;
using RentalOfPremises.Repository.Abstraction;
using RentalOfPremises.ViewModels.Implementation.MainViewModels;

namespace Tests.ViewModels.MainViewModels;

public class PremisesViewModelTests
{
    [Fact]
    public async Task UpdateAsync_CollectionOfPremisesNotNull()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.PremisesRepository.GetAsync(null, null))
            .ReturnsAsync([
                new Premise()
            ]);
        var clientsViewModel = new ClientsViewModel(mockUnitOfWork.Object);

        await clientsViewModel.UpdateAsync();

        Assert.NotNull(clientsViewModel.CollectionOfClients);
    }
}