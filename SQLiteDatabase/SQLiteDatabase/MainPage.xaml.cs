using Xamarin.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using System;

namespace SQLiteDatabase
{
    public partial class MainPage : ContentPage
    {
        SQLiteClient conn;
        public MainPage()
        {
            InitializeComponent();
            TodoItem tdo = new TodoItem();
            conn = new SQLiteClient();
            Add.Clicked += async (s, e) =>
             {
                 tdo.Name = name.Text;

                await  conn.insertOrReplaceNameTodo(tdo);

                 getData.Text = conn.GetNameTodoItems().Name;
                 tdo = conn.GetNameTodoItems();
                 await DisplayAlert("Name", tdo.Name, "Ok");
             };
        }
    }
}