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
    }
}