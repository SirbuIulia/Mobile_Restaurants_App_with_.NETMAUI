using Microsoft.Maui.Devices.Sensors;
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
        await Map.OpenAsync(location, options);
    }
}