using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Semi.Avalonia.Themes.SystemAccentColorsTheme.TestApp.ViewModels;

namespace Semi.Avalonia.Themes.SystemAccentColorsTheme.TestApp.Pages;

public partial class PaletteDemo : UserControl
{
    public PaletteDemo()
    {
        InitializeComponent();
    }

    protected override async  void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        PaletteDemoViewModel? vm = new PaletteDemoViewModel();
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            vm.InitializeResources();
        });
        DataContext = vm;
    }
}