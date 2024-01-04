using System.Windows;
using System.Windows.Controls;

namespace RentalOfPremises.Views.UserControls;

public partial class UcTextBlock : UserControl
{
    private static readonly DependencyProperty BackgroundColorProperty =
        DependencyProperty.Register(nameof(BackgroundColor), typeof(string), typeof(UcTextBlock),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));

    private static readonly DependencyProperty CustomTextProperty =
        DependencyProperty.Register(nameof(CustomText), typeof(string), typeof(UcTextBlock),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
    public UcTextBlock()
    {
        InitializeComponent();
    }

    public string BackgroundColor
    {
        get => (string)GetValue(BackgroundColorProperty);

        set => SetValue(BackgroundColorProperty, value);
    }

    public string CustomText
    {
        get => (string)GetValue(CustomTextProperty);

        set => SetValue(CustomTextProperty, value);
    }
}