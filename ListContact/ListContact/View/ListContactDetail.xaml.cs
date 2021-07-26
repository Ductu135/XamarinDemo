using ListContact.ViewModel;
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
    public partial class ListContactDetail : ContentPage
    {
        private ContactViewModel contactViewModel;
        public ListContactDetail(ContactViewModel contactViewModel)
        {
            this.contactViewModel = contactViewModel;
            InitializeComponent();
            BindingContext = this.contactViewModel;
        }

        private void OnClick(object sender, EventArgs e)
        {

        }
    }
}