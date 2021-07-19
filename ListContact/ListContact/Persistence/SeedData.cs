using ListContact.Model;
using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;

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
                    new Contact{Title = "Title 1", Description = "Description 1"},
                    new Contact{Title = "Title 2", Description = "Description 2"},
                    new Contact{Title = "Title 3", Description = "Description 3"}
                });
            }
        }
    }
}