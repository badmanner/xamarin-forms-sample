using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using System.IO;

namespace SharedApp.Data
{
    public class TaskItemDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        string DatabasePath
        {
            get
            {
                var sqliteFilename = "TodoSQLite.db3";
                #if __IOS__
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(libraryPath, sqliteFilename);
                #else
                #if __ANDROID__
                string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, sqliteFilename);
                #else
                // WinPhone
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
                #endif
                #endif
                return path;
            }
        }

        public TaskItemDatabase()
        {
            database = new SQLiteConnection(DatabasePath);

            database.CreateTable<Task>();
        }

        public IEnumerable<Task> getItems()
        {
            IEnumerable<Task> list = null;
            list = (from i in database.Table<Task>() select i).ToList();
            return list;
        }

        public Task getItem(int id)
        {
            return database.Table<Task>().ElementAt(id);
        }

        public int saveItem(Task item)
        {
            if( item.ID != 0) 
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public void deleteItem(int id)
        {
            database.Delete<Task>(id);
        }


    }
}
