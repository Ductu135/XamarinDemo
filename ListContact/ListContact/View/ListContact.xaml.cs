using ListContact.Common;
using ListContact.Persistence;
using ListContact.ViewModel.ImplementationViewModel;
using SQLite;
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
            ViewModel = new ContactsViewModel(new PageService());
            InitializeComponent();
            connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath);
        }

        protected override async void OnAppearing()
        {
            //var data = await App.Data.GetContacts();
            contactList.ItemsSource = await ViewModel.ShowContacts();
            base.OnAppearing();
        }

        private ContactsViewModel ViewModel
        {
            get => BindingContext as ContactsViewModel;

            set => BindingContext = value;
        }
    }
}