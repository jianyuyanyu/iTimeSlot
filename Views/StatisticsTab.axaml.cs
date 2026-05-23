using Avalonia;
using Avalonia.Controls;
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
        };
        Loaded += (_, _) =>
        {
            RegisterScrollCallback();
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
}
