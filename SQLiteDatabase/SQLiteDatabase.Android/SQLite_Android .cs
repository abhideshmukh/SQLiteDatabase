using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using System.IO;
using SQLiteDatabase.Droid;
using SQLite;
[assembly: Dependency(typeof(SQLite_Android))]
namespace SQLiteDatabase.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {

        }

        #region ISQLite implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath =
              System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(documentsPath, sqliteFilename);
            System.Diagnostics.Debug.WriteLine("Database path android : " + path);

            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            return conn;
        }
        #endregion

    }
}
