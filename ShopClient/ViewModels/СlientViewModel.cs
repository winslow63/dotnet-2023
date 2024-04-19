using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ShopClient.ViewModels;
public class СlientViewModel : ViewModelBase
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

    private string _address = string.Empty;
    [Required]
    public string address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private string _phoneNumber = string.Empty;
    [Required]
    public string phoneNumber
    {
        get => _phoneNumber;
        set => this.RaiseAndSetIfChanged(ref _phoneNumber, value);
    }

    public ReactiveCommand<Unit, СlientViewModel> OnSubmitClientCommand { get; }
    public СlientViewModel()
    {
        OnSubmitClientCommand = ReactiveCommand.Create(() => this);
    }
}

