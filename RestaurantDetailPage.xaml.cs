using Microsoft.Maui.Devices.Sensors;
using Plugin.LocalNotification;
using Proiect_NETMaui.Models;
namespace Proiect_NETMaui;

public partial class RestaurantDetailPage : ContentPage
{
	public RestaurantDetailPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Restaurant)BindingContext;
        //slist.Name = Restaurant.Name;
        await App.Database.SaveRestaurantAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var shop = (Restaurant)BindingContext;
        var address = shop.Address;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "My TastyHeaven Restaurant" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        var distance = myLocation.CalculateDistance(location,DistanceUnits.Kilometers);
        if (distance < 4)
        {
            var request = new NotificationRequest
            {
                Title = "One of your favorite restaurants is nearby!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }

        await Map.OpenAsync(location, options);
    }
    async void OnBookaTableButtonClicked(object sender, EventArgs e)
    {
        // Redirecționează către pagina de rezervare
        await Navigation.PushAsync(new RezervarePage());
    }

}