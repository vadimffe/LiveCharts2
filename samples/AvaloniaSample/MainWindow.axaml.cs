using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaSample;

public class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        DataContext = new MainWindowViewModel();
        LoadContent("Design.LinearGradients");
    }

    private void OnPointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        if ((sender as Border)?.DataContext is not string ctx) throw new Exception("Sample not found");
        LoadContent(ctx.Replace('/', '.'));
    }

    private void LoadContent(string view)
    {
        var content = this.FindControl<ContentControl>("content")!;
        content.Content = Activator.CreateInstance(null!, $"AvaloniaSample.{view}.View")?.Unwrap();
        if (DataContext is not MainWindowViewModel dc) throw new Exception();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
