using ListContact.ViewModel.Interface;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListContact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactDetail : ContentPage
    {
        private IContactViewModel contactViewModel;

        public ListContactDetail(IContactViewModel contactViewModel)
        {
            this.contactViewModel = contactViewModel;
            InitializeComponent();
            BindingContext = this.contactViewModel;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListContactUpdatingForm(contactViewModel));
        }
    }
}