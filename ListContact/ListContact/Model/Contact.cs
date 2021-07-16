using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListContact.Model
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string title;
        public string Title 
        { 
            get => title;
            set {
                if (title == value)
                    return;

                title = value;

                OnPropertyChanged(nameof(Title));
            } 
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                if (description == null)
                    return;

                description = value;

                OnPropertyChanged(nameof(Description));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}