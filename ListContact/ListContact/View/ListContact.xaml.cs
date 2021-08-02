using ListContact.Persistence;
using ListContact.ViewModel;
using ListContact.ViewModel.ImplementationViewModel;
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
            connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath);
            ViewModel = new ContactsViewModel();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (ViewModel == null)
                return;

            ViewModel.Contacts = new ObservableCollection<ContactViewModel>();
            ViewModel.Contacts = await ViewModel.ShowContacts();
            base.OnAppearing();
        }

        private void contactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectedContactCommand.Execute(e.SelectedItem);
        }

        private ContactsViewModel ViewModel
        {
            get => BindingContext as ContactsViewModel;

            set => BindingContext = value;
        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ListContactAddingForm());
        }

        private void OnDelete(object sender, System.EventArgs e)
        {
            var item = (Xamarin.Forms.MenuItem)sender;
            ViewModel.DeleteItem((int)item.CommandParameter);
        }
    }
}