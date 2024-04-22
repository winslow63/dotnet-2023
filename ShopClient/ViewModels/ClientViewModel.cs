using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ShopClient.ViewModels;
public class СlientViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _fio = string.Empty;
    [Required]
    public string FIO
    {
        get => _fio;
        set => this.RaiseAndSetIfChanged(ref _fio, value);
    }

    private string _address = string.Empty;
    [Required]
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private string _phoneNumber = string.Empty;
    [Required]
    public string PhoneNumber
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
