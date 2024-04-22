using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ShopClient.ViewModels;
public class СarViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _carNumber;
    [Required]
    public int CarNumber
    {
        get => _carNumber;
        set => this.RaiseAndSetIfChanged(ref _carNumber, value);
    }

    private string _model = string.Empty;
    [Required]
    public string Model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }

    private int _typeId;
    [Required]
    public int TypeId
    {
        get => _typeId;
        set => this.RaiseAndSetIfChanged(ref _typeId, value);
    }

    public ReactiveCommand<Unit, СarViewModel> OnSubmitCarCommand { get; }
    public СarViewModel()
    {
        OnSubmitCarCommand = ReactiveCommand.Create(() => this);
    }

}