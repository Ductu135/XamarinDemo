using ListContact.Persistence;
using ListContact.ViewModel.Interface;
using SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListContact.ViewModel
{
    public class BaseViewModel : IBaseViewModel
    {
        protected readonly SQLiteAsyncConnection connection;
        public BaseViewModel()
        {
            connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath, BaseConnection.Flags);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
    }
}