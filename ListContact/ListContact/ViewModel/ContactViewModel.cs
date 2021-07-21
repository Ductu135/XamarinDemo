namespace ListContact.ViewModel
{
    public class ContactViewModel : BaseViewModel
    {
        public int Id { get; set; }
        private string title;

        public string Title
        {
            get => title;
            set
            {
                SetValue(ref title, value);
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
    }
}