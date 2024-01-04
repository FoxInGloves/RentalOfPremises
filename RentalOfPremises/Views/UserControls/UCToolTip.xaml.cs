using System.Windows;
using System.Windows.Controls;

namespace RentalOfPremises.Views.UserControls;

public partial class UcToolTip : UserControl
{
    private static readonly DependencyProperty NamePremiseProperty =
        DependencyProperty.Register(nameof(NamePremise), typeof(string), typeof(UcToolTip),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));

    private static readonly DependencyProperty AreaPremiseProperty =
        DependencyProperty.Register(nameof(AreaPremise), typeof(string), typeof(UcToolTip),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    private static readonly DependencyProperty ContractProperty =
        DependencyProperty.Register(nameof(Contract), typeof(string), typeof(UcToolTip),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));

    
    private static readonly DependencyProperty PriceProperty = 
        DependencyProperty.Register(nameof(Price), typeof(string), typeof(UcToolTip),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    private static readonly DependencyProperty ClientProperty = 
        DependencyProperty.Register(nameof(Client), typeof(string), typeof(UcToolTip),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    private static readonly DependencyProperty StartDateProperty = 
        DependencyProperty.Register(nameof(StartDate), typeof(string), typeof(UcToolTip),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    private static readonly DependencyProperty EndDateProperty = 
        DependencyProperty.Register(nameof(EndDate), typeof(string), typeof(UcToolTip),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    public UcToolTip()
    {
        InitializeComponent();
    }
    
    public string NamePremise
    {
        get => (string)GetValue(NamePremiseProperty);
        
        set => SetValue(NamePremiseProperty, value);
    }

    public string AreaPremise
    {
        get => (string)GetValue(AreaPremiseProperty);

        set => SetValue(AreaPremiseProperty, value);
    }

    public string Contract
    {
        get => (string)GetValue(ContractProperty);

        set => SetValue(ContractProperty, value);
    }

    public string Price
    {
        get => (string)GetValue(PriceProperty);
        
        set => SetValue(PriceProperty, value);
    }

    public string Client
    {
        get => (string)GetValue(ClientProperty);

        set => SetValue(ClientProperty, value);
    }
    
    public string StartDate
    {
        get => (string)GetValue(StartDateProperty);

        set => SetValue(StartDateProperty, value);
    }
    
    public string EndDate
    {
        get => (string)GetValue(EndDateProperty);

        set => SetValue(ClientProperty, value);
    }
}