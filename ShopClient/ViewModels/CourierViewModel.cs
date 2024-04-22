using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ShopClient.ViewModels;
public class СourierViewModel : ViewModelBase
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

    private string _telephone = string.Empty;
    [Required]
    public string Telephone
    {
        get => _telephone;
        set => this.RaiseAndSetIfChanged(ref _telephone, value);
    }

    private int _carId;
    [Required]
    public int CarId
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

