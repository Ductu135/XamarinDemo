using ListContact.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListContact.Extension
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditForm : ContentView
    {
        //private static readonly BindableProperty NameProperty = BindableProperty.Create("NameText", typeof(object), typeof(EditForm), BindingMode.TwoWay);

        //public string NameText { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }

        //private static readonly BindableProperty PhoneProperty = BindableProperty.Create("PhoneNumberText", typeof(string), typeof(EditForm), BindingMode.TwoWay);

        //public string PhoneNumberText { get => (string)GetValue(PhoneProperty); set => SetValue(PhoneProperty, value); }

        //private static readonly BindableProperty EmailProperty = BindableProperty.Create("EmailText", typeof(string), typeof(EditForm), BindingMode.TwoWay);

        //public string EmailText { get => (string)GetValue(EmailProperty); set => SetValue(EmailProperty, value); }

        //private static readonly BindableProperty DescriptionProperty = BindableProperty.Create("DescriptionText", typeof(string), typeof(EditForm), BindingMode.TwoWay);

        //public string DescriptionText { get => (string)GetValue(DescriptionProperty); set => SetValue(DescriptionProperty, value); }

        public EditForm()
        {
            InitializeComponent();
            //BindingContext = this;
        }
    }
}