using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Themes.SystemAccentColorsTheme.TestApp.Pages;

public partial class MenuDemo : UserControl
{
    public MenuDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}