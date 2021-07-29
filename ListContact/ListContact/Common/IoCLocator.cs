using GalaSoft.MvvmLight.Ioc;
using ListContact.Common.Interface;
using ListContact.ViewModel;
using ListContact.ViewModel.ImplementationViewModel;
using ListContact.ViewModel.Interface;

namespace ListContact.Common
{
    public class IoCLocator
    {
        public IoCLocator()
        {
            SimpleIoc.Default.Register<IPageService, PageService>();

            SimpleIoc.Default.Register<IContactViewModel, ContactViewModel>();
            SimpleIoc.Default.Register<IContactsViewModel, ContactsViewModel>();
        }

        public IContactViewModel ContactViewModel => SimpleIoc.Default.GetInstance<IContactViewModel>();
        public IContactsViewModel ContactsViewModel => SimpleIoc.Default.GetInstance<IContactsViewModel>();
    }
}