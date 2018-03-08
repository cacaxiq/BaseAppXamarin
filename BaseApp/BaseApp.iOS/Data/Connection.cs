using BaseApp.LocalDatabase.Interface;
using BaseApp.iOS.Data;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Connection))]
namespace BaseApp.iOS.Data
{
    public class Connection : IConnection
    {
        public SQLiteAsyncConnection GetConection(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return new SQLiteAsyncConnection(Path.Combine(libFolder, filename));
        }
    }
}