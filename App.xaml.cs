using System;
using Proiect_NETMaui.Data;
using System.IO;
using Xamarin.Essentials;
namespace Proiect_NETMaui;

public partial class App : Application
{
    static RestaurantDatabase database;
    public static RestaurantDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               RestaurantDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Restaurant.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();
        
        MainPage = new AppShell();
	}
}
