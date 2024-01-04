using System.Windows;
using RentalOfPremises.Services.Navigation;
using RentalOfPremises.ViewModels.Implementation.MainViewModels;
using RentalOfPremises.Views.MainViews;

namespace RentalOfPremises
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationService = new NavigationService();
            
            var viewModel = new MainViewModel(navigationService);

            var view = new MainWindow()
            {
                DataContext = viewModel
            };
            
            view.Show();
        }
    }
}