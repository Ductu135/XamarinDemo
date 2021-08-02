using ListContact.ViewModel.Interface;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListContact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactUpdatingForm : ContentPage
    {
        private IContactViewModel contactViewModel;

        public ListContactUpdatingForm(IContactViewModel contactViewModel = null)
        {
            this.contactViewModel = contactViewModel;
            InitializeComponent();
            BindingContext = this.contactViewModel;
        }
    }
}