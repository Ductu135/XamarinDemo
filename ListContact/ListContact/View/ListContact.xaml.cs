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
            connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath);
            ViewModel = new ContactsViewModel(new PageService());
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
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
    }
}