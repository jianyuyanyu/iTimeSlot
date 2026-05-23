using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using iTimeSlot.ViewModels;

namespace iTimeSlot.Views;

public partial class StatisticsTab : UserControl
{
    public StatisticsTab()
    {
        InitializeComponent();

        DataContextChanged += (_, _) =>
        {
            RegisterScrollCallback();
            ScrollStatToEnd();
        };
        Loaded += (_, _) =>
        {
            RegisterScrollCallback();
            UpdateRangeButtonState();
            ScrollStatToEnd();
        };
    }

    private void RegisterScrollCallback()
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.ScrollStatToEnd = ScrollStatToEnd;
        }
    }

    private void ScrollStatToEnd()
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var extent = StatScrollViewer.Extent.Width;
            var viewport = StatScrollViewer.Viewport.Width;
            if (extent > viewport)
            {
                StatScrollViewer.Offset = new Vector(extent - viewport, 0);
            }
        }, DispatcherPriority.Loaded);
    }

    private void StatRange3_Click(object? sender, RoutedEventArgs e)
    {
        SetStatRange(0);
    }

    private void StatRange7_Click(object? sender, RoutedEventArgs e)
    {
        SetStatRange(1);
    }

    private void StatRange30_Click(object? sender, RoutedEventArgs e)
    {
        SetStatRange(2);
    }

    private void StatRange365_Click(object? sender, RoutedEventArgs e)
    {
        SetStatRange(3);
    }

    private void SetStatRange(int index)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.StatRangeIndex = index;
            UpdateRangeButtonState();
        }
    }

    private void UpdateRangeButtonState()
    {
        if (DataContext is not MainWindowViewModel vm)
        {
            return;
        }

        StatRange3Btn.IsEnabled = vm.StatRangeIndex != 0;
        StatRange7Btn.IsEnabled = vm.StatRangeIndex != 1;
        StatRange30Btn.IsEnabled = vm.StatRangeIndex != 2;
        StatRange365Btn.IsEnabled = vm.StatRangeIndex != 3;
    }
}
