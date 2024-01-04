using System;
using System.Reflection;
using System.Windows.Controls;
using RentalOfPremises.ViewModels.Abstraction;

namespace RentalOfPremises.Services.Navigation;

public class NavigationService
{
    public (Page, BaseViewModel) Navigate(BaseViewModel viewModel)
    {
        var pageAndVm = GetView(viewModel);

        pageAndVm.Item1.DataContext = viewModel;

        return pageAndVm;
    }

    private (Page, BaseViewModel) GetView(BaseViewModel viewModel)
    {
        var viewModelType = viewModel.GetType();
        
        var viewName = viewModelType.FullName?.Replace("ViewModels.Implementation.MainViewModels", "Views.MainViews")
            .Replace("ViewModel", "Page");

        if (viewName is null) throw new ArgumentNullException(viewName);

        var viewType = Assembly.GetExecutingAssembly().GetType(viewName);
        
        return (Activator.CreateInstance(viewType) as Page, viewModel);
    }
}