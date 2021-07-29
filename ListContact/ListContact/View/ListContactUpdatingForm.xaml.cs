using ListContact.ViewModel;
using ListContact.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListContact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactUpdatingForm : ContentPage
    {
        private IContactViewModel contactViewModel;
        public ListContactUpdatingForm(IContactViewModel contactViewModel)
        {
            this.contactViewModel = contactViewModel;
            InitializeComponent();
            BindingContext = this.contactViewModel;
        }
    }
}