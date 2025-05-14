using MauiAppInterfaz.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MauiAppInterfaz.Services
{
    public class DatabaseService
    {
        public SQLiteAsyncConnection _database;
        public bool _initialized;

        public async Task InitAsync()
        {
            if (_initialized)
                return;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clients.db");

#if DEBUG
            if (File.Exists(dbPath))
                File.Delete(dbPath); // For dev testing
#endif

            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<Client>();

            var count = await _database.Table<Client>().CountAsync();
            if (count == 0)
            {
                var defaultClients = new List<Client>
                {
                    new Client { Name = "Juan Pérez", Email = "juan.perez@email.com" },
                    new Client { Name = "María López", Email = "maria.lopez@email.com" },
                    new Client { Name = "Carlos Sánchez", Email = "carlos.sanchez@email.com" }
                };

                await _database.InsertAllAsync(defaultClients);
            }

            _initialized = true;
        }

        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }
    }
}
