﻿using ListContact.Common;
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
            }
        }

        public ICommand SelectedContactCommand { get; private set; }
        public ICommand ShowContactsCommand { get; private set; }

        public ContactsViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            SelectedContactCommand = new Command<ContactViewModel>(async vm => await SelectContact(vm));
            Task.Run(async () => await ShowContacts());
        }

        public async Task<ObservableCollection<ContactViewModel>> ShowContacts()
        {
            var listContacts = await connection.Table<Contact>().ToListAsync();
            foreach (var item in listContacts)
            {
                Contacts.Add(new ContactViewModel(new PageService())
                {
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    Description = item.Description
                });
            }

            return Contacts;
        } 

        private async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            await pageService.PushAsycn(new ListContactDetail(contact));
        }
    }
}