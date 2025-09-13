using AppointmentSimulator.ViewModels;
using AppointmentSimulator.Views;

namespace AppointmentSimulator.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new AppointmentViewModel();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddNewAppointmentPage));
    }
}


