using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using URLShortner.Models;

namespace URLShortner.Services
{
	public static class URLStorageService
	{
		static SQLiteAsyncConnection db;

		static async Task Init()
		{
			if (db != null)
				return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<URL>();
        }

		public static async Task AddURL(URL uRL)
		{
            await Init();

            await db.InsertAsync(uRL);
		}

        public static async Task DeleteURL(URL uRL)
        {
            await Init();

            await db.DeleteAsync(uRL);
        }

        public static async Task<IEnumerable<URL>> GetURL()
        {
            await Init();

            return await db.Table<URL>().ToListAsync();
        }
    }
}

