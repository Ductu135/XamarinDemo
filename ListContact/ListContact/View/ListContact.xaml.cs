using ListContact.Model;
using ListContact.Persistence;
using SQLite;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListContact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContact : ContentPage
    {
        private SQLiteAsyncConnection connection;

        public ListContact()
        {
            InitializeComponent();
            connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath);
        }

        protected override async void OnAppearing()
        {
            var data = await App.Data.GetContacts();
            contactList.ItemsSource = data;
            base.OnAppearing();
        }
    }
}