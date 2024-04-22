using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ShopClient.ViewModels;
using System.Threading.Tasks;

namespace ShopClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowCarDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowClientDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowCourierDialog.RegisterHandler(ShowDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowShopDialog.RegisterHandler(ShowDialogAsync)));
    }
    private async Task ShowDialogAsync(InteractionContext<ÑarViewModel, ÑarViewModel?> interaction)
    {
        var dialog = new CarWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ÑarViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogAsync(InteractionContext<ÑlientViewModel, ÑlientViewModel?> interaction)
    {
        var dialog = new ClientWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ÑlientViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogAsync(InteractionContext<ÑourierViewModel, ÑourierViewModel?> interaction)
    {
        var dialog = new CourierWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ÑourierViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowDialogAsync(InteractionContext<ShopViewModel, ShopViewModel?> interaction)
    {
        var dialog = new ShopWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<ShopViewModel?>(this);
        interaction.SetOutput(result);
    }
}
