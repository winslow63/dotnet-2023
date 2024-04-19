using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ShopClient.ViewModels;
using System;

namespace ShopClient.Views
{
    public partial class CourierWindow : ReactiveWindow<ÑourierViewModel>
    {
        public CourierWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.OnSubmitCourierCommand.Subscribe(Close)));
        }

        public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
