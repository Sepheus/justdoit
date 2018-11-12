using System;
using System.IO;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(justdoit.Droid.SQLite_Android))]

namespace justdoit.Droid {
    class SQLite_Android : ISQLite {
        public SQLite_Android() {

        }

        /// <summary>
        /// Android specific code for initiating the DB connection.
        /// </summary>
        /// <returns>A new SQLite3 DB instance.</returns>
        public SQLiteConnection GetConnection() {
            const string filename = "tasks.db";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, filename);
            return new SQLiteConnection(path, true);
        }

    }
}