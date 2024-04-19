using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ShopClient.ViewModels;
using ShopClient.Views;
using Splat;

namespace ShopClient;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSGetDto, �arViewModel>();
                cfg.CreateMap<�arViewModel, TSPostDto>();
                cfg.CreateMap<ClientGetDto, �lientViewModel>();
                cfg.CreateMap<�lientViewModel, ClientPostDto>();
                cfg.CreateMap<CourierGetDto, �ourierViewModel>();
                cfg.CreateMap<�ourierViewModel, CourierPostDto>();
                cfg.CreateMap<ShopGetDto, ShopViewModel>();
                cfg.CreateMap<ShopViewModel, ShopPostDto>();
                cfg.CreateMap<ShopPostDto, ShopViewModel>();
                cfg.CreateMap<ShopViewModel, ShopGetDto>();
                cfg.CreateMap<ShopViewModel, ShopViewModel>();
            });
            Locator.CurrentMutable.RegisterConstant(new ApiWrapper());
            Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
