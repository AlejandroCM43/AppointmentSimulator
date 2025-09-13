using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using AppointmentSimulator.Models;

namespace AppointmentSimulator.ViewModels
{
    public class AppointmentViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; } = DateTime.Today;
        public TimeSpan StartingTime { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan EndingTime { get; set; } = new TimeSpan(9, 30, 0);

        public Appointment SelectedAppointment { get; set; }

        public ObservableCollection<Appointment> Appointments { get; } = GlobalData.Appointments;

        public ICommand AddAppointmentCommand { get; }
        public ICommand DeleteAppointmentCommand { get; }

        public AppointmentViewModel()
        {
            AddAppointmentCommand = new Command(AddAppointment);
            DeleteAppointmentCommand = new Command(DeleteAppointment);
        }

        private async void AddAppointment()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Subject))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (AppointmentDate.Date < DateTime.Today)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "La fecha debe ser hoy o en el futuro.", "OK");
                return;
            }

            if (StartingTime >= EndingTime)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "La hora de inicio debe ser menor a la de término.", "OK");
                return;
            }

            Appointments.Add(new Appointment
            {
                Name = Name,
                Subject = Subject,
                AppointmentDate = DateOnly.FromDateTime(AppointmentDate),
                StartingTime = StartingTime,
                EndingTime = EndingTime
            });

            await Application.Current.MainPage.DisplayAlert("Éxito", "Cita agregada correctamente.", "OK");
        }

        private async void DeleteAppointment()
        {
            if (SelectedAppointment == null)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Selecciona una cita para eliminar.", "OK");
                return;
            }

            Appointments.Remove(SelectedAppointment);
            SelectedAppointment = null;
            await Application.Current.MainPage.DisplayAlert("Listo", "Cita eliminada.", "OK");
        }
    }
}
