using ListContact.Model;
using SQLite;
using System.Linq;

namespace ListContact.Persistence
{
    public class SeedData
    {
        private readonly SQLiteAsyncConnection connection;

        public SeedData()
        {
            connection = new SQLiteAsyncConnection(BaseConnection.DatabasePath, BaseConnection.Flags);
            connection.CreateTableAsync<Contact>().Wait();
            SeedContacts();
        }

        public async void SeedContacts()
        {
            var contacts = await connection.Table<Contact>().ToListAsync();
            if (!contacts.Any())
            {
                await connection.InsertAllAsync(new Contact[]
                {
                    new Contact{Title = "Title 1", Description = "Description 1", PhoneNumber = "0778354425", Email = "Email1@gmail.com"},
                    new Contact{Title = "Title 2", Description = "Description 2", PhoneNumber = "0124578914", Email = "Email2@gmail.com"},
                    new Contact{Title = "Title 3", Description = "Description 3", PhoneNumber = "0975615188", Email = "Email3@gmail.com"},
                    new Contact{Title = "Title 4", Description = "Description 4", PhoneNumber = "0241816548", Email = "Email4@gmail.com"}
                });
            }
        }
    }
}