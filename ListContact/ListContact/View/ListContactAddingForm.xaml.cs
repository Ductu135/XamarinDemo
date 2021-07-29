using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListContact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactAddingForm : ContentPage
    {
        //private SQLiteAsyncConnection connection;

        public ListContactAddingForm()
        {
            //connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath);
            InitializeComponent();
        }
    }
}