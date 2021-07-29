using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListContact.ViewModel.Interface
{
    public interface IContactsViewModel : IBaseViewModel
    {
        ObservableCollection<ContactViewModel> Contacts { get; set; }

        ContactViewModel SelectedContact { get; set; }

        ICommand SelectedContactCommand { get; set; }

        ICommand ShowContactsCommand { get; set; }

        Task SelectContact(ContactViewModel contact);

        Task<ObservableCollection<ContactViewModel>> ShowContacts();
    }
}





