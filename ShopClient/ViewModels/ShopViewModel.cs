﻿using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ShopClient.ViewModels;
public class ShopViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _courierId;
    [Required]
    public int CourierId
    {
        get => _courierId;
        set => this.RaiseAndSetIfChanged(ref _courierId, value);
    }

    private int _clientId;
    [Required]
    public int ClientId
    {
        get => _clientId;
        set => this.RaiseAndSetIfChanged(ref _clientId, value);
    }

    private DateTimeOffset _dateTimeOrder = DateTime.Now;
    [Required]
    public DateTimeOffset DateTimeOrder
    {
        get => _dateTimeOrder;
        set => this.RaiseAndSetIfChanged(ref _dateTimeOrder, value);
    }

    private DateTimeOffset _dateTimeDelivery = DateTime.Now;
    [Required]
    public DateTimeOffset DateTimeDelivery
    {
        get => _dateTimeDelivery;
        set => this.RaiseAndSetIfChanged(ref _dateTimeDelivery, value);
    }

    private DateTimeOffset _dateTimeDeliveryActual = DateTime.Now;
    [Required]
    public DateTimeOffset DateTimeDeliveryActual
    {
        get => _dateTimeDeliveryActual;
        set => this.RaiseAndSetIfChanged(ref _dateTimeDeliveryActual, value);
    }

    private int _orderNumber;
    [Required]
    public int OrderNumber
    {
        get => _orderNumber;
        set => this.RaiseAndSetIfChanged(ref _orderNumber, value);
    }

    private string _status = string.Empty;
    [Required]
    public string Status
    {
        get => _status;
        set => this.RaiseAndSetIfChanged(ref _status, value);
    }

    private int _typeId;
    [Required]
    public int TypeId
    {
        get => _typeId;
        set => this.RaiseAndSetIfChanged(ref _typeId, value);
    }

    public ReactiveCommand<Unit, ShopViewModel> OnSubmitShopCommand { get; }

    public ShopViewModel()
    {
        OnSubmitShopCommand = ReactiveCommand.Create(() => this);
    }


}