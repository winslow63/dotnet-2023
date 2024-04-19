using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

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
    public int carNumber
    {
        get => _carNumber;
        set => this.RaiseAndSetIfChanged(ref _carNumber, value);
    }

    private string _model = string.Empty;
    [Required]
    public string model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }

    private int _typeId;
    [Required]
    public int typeId
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

