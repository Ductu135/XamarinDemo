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
        public ListContactDetail(ContactViewModel contactViewModel)
        {
            InitializeComponent();
        }
    }
}