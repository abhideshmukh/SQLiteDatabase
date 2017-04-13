using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLiteDatabase;
using SQLite.Net;
using SQLiteDatabase.iOS;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_iOS))]
namespace SQLiteDatabase.iOS
{
    public class SQLite_iOS : ISQLite
    {
        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLiteDownload.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            System.Diagnostics.Debug.WriteLine("Database path iOS : " + path);
            //			// This is where we copy in the prepopulated database
            //			Console.WriteLine (path);
            //			if (!File.Exists (path)) {
            //				File.Copy (sqliteFilename, path);
            //			}


            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();


            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}