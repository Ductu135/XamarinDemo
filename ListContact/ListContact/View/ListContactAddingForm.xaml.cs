using ListContact.Common;
using ListContact.Persistence;
using ListContact.ViewModel;
using ListContact.ViewModel.ImplementationViewModel;
using SQLite;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListContact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactAddingForm : ContentPage
    {
        private SQLiteAsyncConnection connection;

        public ListContactAddingForm()
        {
            connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath);
            ViewModel = new ContactViewModel(new PageService());
            InitializeComponent();
        }

        private ContactViewModel ViewModel
        {
            get => BindingContext as ContactViewModel;

            set => BindingContext = value;
        }
    }
}