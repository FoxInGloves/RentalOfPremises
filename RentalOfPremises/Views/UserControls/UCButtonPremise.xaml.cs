using System.Windows;
using System.Windows.Controls;

namespace RentalOfPremises.Views.UserControls;

public partial class UcButtonPremise : UserControl
{
    private new static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.Register(nameof(BackgroundColor), typeof(string), typeof(UcButtonPremise),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    private static readonly DependencyProperty NamePremiseProperty =
        DependencyProperty.Register(nameof(NamePremise), typeof(string), typeof(UcButtonPremise),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    private static readonly DependencyProperty AreaPremiseProperty =
        DependencyProperty.Register(nameof(AreaPremise), typeof(string), typeof(UcButtonPremise),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    
    public UcButtonPremise()
    {
        InitializeComponent();
    }

    public string BackgroundColor
    {
        get => (string)GetValue(BackgroundProperty);

        set => SetValue(BackgroundProperty, value);
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
}