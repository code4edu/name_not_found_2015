using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace QuickTester
{
    public class DatabaseWork
    {
        public static void InitBD()
        {
            var dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Questions.db");

            using (var db = new SQLiteConnection(dbPath))
            {
                db.CreateTable<IQuestion>();
            }
        }
    }
}
