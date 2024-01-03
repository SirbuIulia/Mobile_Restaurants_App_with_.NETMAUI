using Plugin.LocalNotification;
using Proiect_NETMaui.Models;
using Xamarin.Essentials;
namespace Proiect_NETMaui;

public partial class RezervarePage : ContentPage
{
	public RezervarePage()
	{
		InitializeComponent();
	}
    async void OnCompleteReservationClicked(object sender, EventArgs e)
    {
        // Check if the number of persons is entered correctly
        if (int.TryParse(numarPersoaneEntry.Text, out int numarPersoane))
        {
            // Save date, time, and number of persons in the reservation object
            DateTime selectedDate = datePicker.Date;
            TimeSpan selectedTime = timePicker.Time;

            // Example: Save the data in a reservation object (assuming you have access to this object)
            Rezervare reservation = new Rezervare
            {
                Data = selectedDate,
                Ora = selectedTime,
                NumarPersoane = numarPersoane
                // Other attributes of the Reservation object can be set here
            };
            ScheduleNotification("Reservation Confirmation", $"Your reservation for {numarPersoane} persons on {selectedDate.ToLocalTime()} is confirmed.");

            // Schedule reminder notification one day before the reservation
            ScheduleNotification("Reservation Reminder", $"Don't forget your reservation for {numarPersoane} persons tomorrow at {selectedDate.ToLocalTime().AddDays(-1)}.");


            // Navigate back to the previous page or perform other actions
            Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid number of persons.", "OK");
        }
    }
    private void ScheduleNotification(string title, string message)
    {
        var notification = new NotificationRequest
        {
            Title = title,
            Description = message,
            ReturningData = "Dummy data for returning"
        };

        LocalNotificationCenter.Current.Show(notification);

    }
}
