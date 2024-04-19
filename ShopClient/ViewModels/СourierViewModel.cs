using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ShopClient.ViewModels;

public class СourierViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _FIO = string.Empty;
    [Required]
    public string FIO
    {
        get => _FIO;
        set => this.RaiseAndSetIfChanged(ref _FIO, value);
    }

    private string _telephone = string.Empty;
    [Required]
    public string telephone
    {
        get => _telephone;
        set => this.RaiseAndSetIfChanged(ref _telephone, value);
    }

    private int _carId;
    [Required]
    public int carId
    {
        get => _carId;
        set => this.RaiseAndSetIfChanged(ref _carId, value);
    }

    public ReactiveCommand<Unit, СourierViewModel> OnSubmitCourierCommand { get; }
    public СourierViewModel()
    {
        OnSubmitCourierCommand = ReactiveCommand.Create(() => this);
    }

}

