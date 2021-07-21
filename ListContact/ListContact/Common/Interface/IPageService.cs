using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListContact.Common.Interface
{
    public interface IPageService
    {
        Task PushAsycn(Page page);
        Task PushModalAsycn(Page page);
        Task PopModalAsycn(Page page);
        Task PopAsycn();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
    }
}