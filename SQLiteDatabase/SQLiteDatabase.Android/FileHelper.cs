using System;

using SQLiteDatabase.Droid;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]

namespace SQLiteDatabase.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}