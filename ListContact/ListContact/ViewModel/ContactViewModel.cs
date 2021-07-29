using ListContact.Common.Interface;
using ListContact.Model;
using ListContact.ViewModel;
using ListContact.ViewModel.Interface;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

[assembly:Dependency(typeof(ContactViewModel))]
namespace ListContact.ViewModel
{
    public class ContactViewModel : BaseViewModel, IContactViewModel
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

        public ICommand AddContactCommand { get; set; }

        private IPageService pageService;

        public ContactViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            AddContactCommand = new Command(async () => await AddContacts());
        }

        public async Task AddContacts()
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