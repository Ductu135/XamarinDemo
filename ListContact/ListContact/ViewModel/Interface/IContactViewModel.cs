using ListContact.Common.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListContact.ViewModel.Interface
{
    public interface IContactViewModel : IBaseViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string PhoneNumber { get; set; }

        string Email { get; set; }

        ICommand AddContactCommand { get; set; }

        Task AddContacts();
    }
}
