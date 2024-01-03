using Proiect_NETMaui.Models;

namespace Proiect_NETMaui;

public partial class RestaurantPage : ContentPage
{
	public RestaurantPage()
	{
        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRestaurantAsync();
    }
    async void OnRestaurantAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RestaurantDetailPage
        {
            BindingContext = new Restaurant()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RestaurantDetailPage
            {
                BindingContext = e.SelectedItem as Restaurant
            });
        }
    }
}