using ListContact.Common.Interface;
using ListContact.Model;
using ListContact.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListContact.ViewModel.ImplementationViewModel
{
    public class ContactsViewModel : BaseViewModel
    {
        public ObservableCollection<ContactViewModel> Contacts { get; set; } = new ObservableCollection<ContactViewModel>();
        private readonly IPageService pageService;

        private ContactViewModel selectedContact;

        public ContactViewModel SelectedContact
        {
            get => selectedContact;
            set
            {
                SetValue(ref selectedContact, value);
                OnPropertyChanged();
            }
        }

        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        public ContactsViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            AddPlaylistCommand = new Command(AddContacts);
            //SelectPlaylistCommand = new Command<ContactViewModel>(async vm => await SelectPlaylistAsync(vm));
        }

        public async Task<ObservableCollection<ContactViewModel>> ShowContacts()
        {
            var listContacts = await connection.Table<Contact>().ToListAsync();
            var ocContacts = new ObservableCollection<ContactViewModel>();
            foreach (var item in listContacts)
            {
                ocContacts.Add(new ContactViewModel()
                {
                    Title = item.Title,
                    Description = item.Description
                });
            }

            return ocContacts;
        } 

        private void AddContacts()
        {
            //TODO Add new contact into database
            //var newPlaylist = "Contact " + (Contacts.Count + 1);
            //Contacts.Add(new ContactViewModel { Title = newPlaylist });
        }

        private async Task SelectPlaylistAsync(ContactViewModel contact)
        {
            if (contact == null)
                return;

            await pageService.PushAsycn(new ListContactDetail(contact));
        }
    }
}