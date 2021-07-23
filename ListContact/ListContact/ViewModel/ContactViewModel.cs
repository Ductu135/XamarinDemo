using ListContact.Common.Interface;
using ListContact.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListContact.ViewModel
{
    public class ContactViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                SetValue(ref name, value);
            }
        }

        private string description;

        public string Description
        {
            get => description;
            set
            {
                SetValue(ref description, value);
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                SetValue(ref phoneNumber, value);
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                SetValue(ref email, value);
            }
        }

        public ICommand AddContactCommand { get; private set; }
        private IPageService pageService;
        public object Alert { get; private set; }

        public ContactViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            AddContactCommand = new Command(async () => await AddContacts());
        }

        private async Task AddContacts()
        {
            var newContact = new Contact()
            {
                Name = Name,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Description = Description
            };

            var result = await connection.InsertAsync(newContact);

            if (result == 1)
                await App.Current.MainPage.DisplayAlert("Successfully", "", "OK");

            await pageService.PopAsycn();
        }
    }
}