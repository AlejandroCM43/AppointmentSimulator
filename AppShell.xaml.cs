using AppointmentSimulator.Views;

namespace AppointmentSimulator;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Aquí registras la página de alta
        Routing.RegisterRoute(nameof(AddNewAppointmentPage), typeof(AddNewAppointmentPage));
    }
}
