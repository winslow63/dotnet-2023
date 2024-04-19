using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;


namespace ShopClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<СarViewModel> Cars { get; } = new();
    public ObservableCollection<СlientViewModel> Clients { get; } = new();
    public ObservableCollection<СourierViewModel> Couriers { get; } = new();
    public ObservableCollection<ShopViewModel> Shops { get; } = new();

    private СarViewModel? _selectedCar;
    public СarViewModel? SelectedCar
    {
        get => _selectedCar;
        set => this.RaiseAndSetIfChanged(ref _selectedCar, value);
    }

    private СlientViewModel? _selectedClient;
    public СlientViewModel? SelectedClient
    {
        get => _selectedClient;
        set => this.RaiseAndSetIfChanged(ref _selectedClient, value);
    }

    private СourierViewModel? _selectedCourier;
    public СourierViewModel? SelectedCourier
    {
        get => _selectedCourier;
        set => this.RaiseAndSetIfChanged(ref _selectedCourier, value);
    }

    private ShopViewModel? _selectedShop;
    public ShopViewModel? SelectedShop
    {
        get => _selectedShop;
        set => this.RaiseAndSetIfChanged(ref _selectedShop, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;


    public ReactiveCommand<Unit, Unit> OnAddCommandCar { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandCar { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandCar { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandClient { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandClient { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandClient { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandCourier { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandCourier { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandCourier { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCommandShop { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommandShop { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommandShop { get; set; }


    public Interaction<СarViewModel, СarViewModel?> ShowCarDialog { get; }
    public Interaction<СlientViewModel, СlientViewModel?> ShowClientDialog { get; }
    public Interaction<СourierViewModel, СourierViewModel?> ShowCourierDialog { get; }
    public Interaction<ShopViewModel, ShopViewModel?> ShowShopDialog { get; }


    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowCarDialog = new Interaction<СarViewModel, СarViewModel?>();
        ShowClientDialog = new Interaction<СlientViewModel, СlientViewModel?>();
        ShowCourierDialog = new Interaction<СourierViewModel, СourierViewModel?>();
        ShowShopDialog = new Interaction<ShopViewModel, ShopViewModel?>();

        OnAddCommandCar = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(new СarViewModel());
            if (carViewModel != null)
            {
                var newCer = _mapper.Map<TSPostDto>(carViewModel);
                await _apiClient.AddCarAsync(newCer);
                Cars.Add(carViewModel);
            }
        });

        OnAddCommandClient = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(new СlientViewModel());
            if (clientViewModel != null)
            {
                var newClient = _mapper.Map<ClientPostDto>(clientViewModel);
                await _apiClient.AddClientAsync(newClient);
                Clients.Add(clientViewModel);
            }
        });

        OnAddCommandCourier = ReactiveCommand.CreateFromTask(async () =>
        {
            var courierViewModel = await ShowCourierDialog.Handle(new СourierViewModel());
            if (courierViewModel != null)
            {
                var newCourier = _mapper.Map<CourierPostDto>(courierViewModel);
                await _apiClient.AddCourierAsync(newCourier);
                Couriers.Add(courierViewModel);
            }
        });

        OnAddCommandShop = ReactiveCommand.CreateFromTask(async () =>
        {
            var shopViewModel = await ShowShopDialog.Handle(new ShopViewModel());
            if (shopViewModel != null)
            {
                var newshop = _mapper.Map<ShopPostDto>(shopViewModel);
                await _apiClient.AddShopAsync(newshop);
                Shops.Add(shopViewModel);
            }
        });



        OnChangeCommandCar = ReactiveCommand.CreateFromTask(async () =>
        {
            var carViewModel = await ShowCarDialog.Handle(SelectedCar!);
            if (carViewModel != null)
            {
                await _apiClient.UpdateCarAsync(SelectedCar.Id, _mapper.Map<TSPostDto>(carViewModel));
                _mapper.Map(carViewModel, SelectedCar);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCar).Select(selectedCar => selectedCar != null));

        OnChangeCommandClient = ReactiveCommand.CreateFromTask(async () =>
        {
            var clientViewModel = await ShowClientDialog.Handle(SelectedClient!);
            if (clientViewModel != null)
            {
                await _apiClient.UpdateClientAsync(SelectedClient.Id, _mapper.Map<ClientPostDto>(clientViewModel));
                _mapper.Map(clientViewModel, SelectedClient);
            }
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectedClient => selectedClient != null));

        OnChangeCommandCourier = ReactiveCommand.CreateFromTask(async () =>
        {
            var courierViewModel = await ShowCourierDialog.Handle(SelectedCourier!);
            if (courierViewModel != null)
            {
                await _apiClient.UpdateCourierAsync(SelectedCourier.Id, _mapper.Map<CourierPostDto>(courierViewModel));
                _mapper.Map(courierViewModel, SelectedCourier);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCourier).Select(selectedCourier => selectedCourier != null));


        OnChangeCommandShop = ReactiveCommand.CreateFromTask(async () =>
        {
            var shopViewModel = await ShowShopDialog.Handle(SelectedShop!);
            if (shopViewModel != null)
            {
                await _apiClient.UpdateCourierAsync(SelectedShop.Id, _mapper.Map<ShopPostDto>(shopViewModel));
                _mapper.Map(shopViewModel, SelectedShop);
            }
        }, this.WhenAnyValue(vm => vm.SelectedShop).Select(selectedShop => selectedShop != null));




        OnDeleteCommandCar = ReactiveCommand.CreateFromTask(async () =>
        {

            await _apiClient.DeleteCarAsync(SelectedCar.Id);
            Cars.Remove(SelectedCar);
        }, this.WhenAnyValue(vm => vm.SelectedCar).Select(selectedCar => selectedCar != null));

        OnDeleteCommandClient = ReactiveCommand.CreateFromTask(async () =>
        {

            await _apiClient.DeleteClientAsync(SelectedClient.Id);
            Clients.Remove(SelectedClient);
        }, this.WhenAnyValue(vm => vm.SelectedClient).Select(selectedClient => selectedClient != null));

        OnDeleteCommandCourier = ReactiveCommand.CreateFromTask(async () =>
        {

            await _apiClient.DeleteCourierAsync(SelectedCourier.Id);
            Couriers.Remove(SelectedCourier);
        }, this.WhenAnyValue(vm => vm.SelectedCourier).Select(selectedCourier => selectedCourier != null));

        OnDeleteCommandShop = ReactiveCommand.CreateFromTask(async () =>
        {

            await _apiClient.DeleteShopAsync(SelectedShop.Id);
            Shops.Remove(SelectedShop);
        }, this.WhenAnyValue(vm => vm.SelectedShop).Select(selectedShop => selectedShop != null));



        RxApp.MainThreadScheduler.Schedule(LoadAllAsync);
    }



    private async void LoadAllAsync()
    {
        var clients = await _apiClient.GetClientAsync();
        foreach (var client in clients)
        {
            Clients.Add(_mapper.Map<СlientViewModel>(client));
        }

        var couriers = await _apiClient.GetCourierAsync();
        foreach (var courier in couriers)
        {
            Couriers.Add(_mapper.Map<СourierViewModel>(courier));
        }

        var cars = await _apiClient.GetCarAsync();
        foreach (var car in cars)
        {
            Cars.Add(_mapper.Map<СarViewModel>(car));
        }

        var shops = await _apiClient.GetShopAsync();
        foreach (var shop in shops)
        {
            Shops.Add(_mapper.Map<ShopViewModel>(shop));
        }
    }



}

