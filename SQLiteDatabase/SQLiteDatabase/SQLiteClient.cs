using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteDatabase
{
    public class SQLiteClient
    {
        private static SQLiteClient instance = null;
        private static readonly object padlock = new object();

        //private static readonly AsyncLock Mutex = new AsyncLock();
        SQLite.Net.SQLiteConnection _connection;


        public static SQLiteClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SQLiteClient();
                        }
                    }
                }
                return instance;
            }
        }

        public SQLiteClient()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            CreateDatabaseAsync();
        }

        public async Task CreateDatabaseAsync()
        {
            _connection.CreateTable<TodoItem>();
        }

        public async Task insertOrReplaceNameTodo(TodoItem Name)
        {
            _connection.InsertOrReplace(Name);
        }

        public TodoItem GetNameTodoItems()
        {
            //return _connection.Table<SignUpClass>().FirstOrDefault();
            return _connection.Table<TodoItem>().LastOrDefault();
        }

    }
}
