using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ShopClient.ViewModels;
using System;

namespace ShopClient.Views;
public partial class ClientWindow : ReactiveWindow<ÑlientViewModel>
{
    public ClientWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitClientCommand.Subscribe(Close)));
    }

    public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}

