using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using CommunityToolkit.Mvvm.Messaging;
using Semi.Avalonia.Themes.SystemAccentColorsTheme.TestApp.ViewModels;

namespace Semi.Avalonia.Themes.SystemAccentColorsTheme.TestApp.Controls;

public class ColorItemControl : TemplatedControl
{
    public static readonly StyledProperty<string?> ColorNameProperty = AvaloniaProperty.Register<ColorItemControl, string?>(
        nameof(ColorName));

    public string? ColorName
    {
        get => GetValue(ColorNameProperty);
        set => SetValue(ColorNameProperty, value);
    }

    public static readonly StyledProperty<string?> HexProperty = AvaloniaProperty.Register<ColorItemControl, string?>(
        nameof(Hex));

    public string? Hex
    {
        get => GetValue(HexProperty);
        set => SetValue(HexProperty, value);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        if (DataContext is ColorItemViewModel v)
        {
            WeakReferenceMessenger.Default.Send(v);
        }

    }
}