using ListContact.Common;
using ListContact.Common.Interface;
using ListContact.Model;
using ListContact.View;
using ListContact.ViewModel.Interface;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListContact.ViewModel.ImplementationViewModel
{
    public class ContactsViewModel : BaseViewModel, IContactsViewModel
    {
        private ObservableCollection<ContactViewModel> contacts;
        public ObservableCollection<ContactViewModel> Contacts 
        {
            get => contacts;
            set
            {
                SetValue(ref contacts, value);
            }
        }
        private readonly IPageService pageService;

        private ContactViewModel selectedContact;

        public ContactViewModel SelectedContact
        {
            get => selectedContact;
            set
            {
                SetValue(ref selectedContact, value);
            }
        }

        public ICommand SelectedContactCommand { get; set; }
        public ICommand ShowContactsCommand { get; set; }

        public ContactsViewModel()
        {
            this.pageService = new PageService();
            SelectedContact = new ContactViewModel();
            SelectedContactCommand = new Command<ContactViewModel>(async vm => await SelectContact(vm));
        }

        public async Task<ObservableCollection<ContactViewModel>> ShowContacts()
        {
            var listContacts = await connection.Table<Contact>().ToListAsync();
            foreach (var item in listContacts)
            {
                Contacts.Add(new ContactViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    Description = item.Description
                });
            }

            return Contacts;
        }

        public async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            await pageService.PushAsycn(new ListContactDetail(contact));
        }

        public async void DeleteItem(int id)
        {
            var model = Contacts.FirstOrDefault(x => x.Id == id);
            await SelectedContact.DeleteContact(model);
            Contacts.Remove(model);
        }
    }
}