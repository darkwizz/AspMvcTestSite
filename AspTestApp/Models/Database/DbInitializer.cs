using AspTestApp.Migrations;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspTestApp.Models.Database
{
    public class DbInitializer: MigrateDatabaseToLatestVersion<LibraryDbContext, Configuration>
    {
        private static Logger LOG = LogManager.GetCurrentClassLogger();
        private string appDataPath = null;

        public DbInitializer(string appDataPath):
            base()
        {
            this.appDataPath = appDataPath;
        }

        public override void InitializeDatabase(LibraryDbContext context)
        {
            if (context.Database.Exists())
            {
                return;
            }
            try
            {
                context.Database.CreateIfNotExists();
                string sqlInitQuery = new StreamReader(
                    new FileStream(appDataPath + "InitScript.sql", FileMode.Open))
                    .ReadToEnd();
                context.Database.ExecuteSqlCommand(sqlInitQuery);
            }
            catch (DbException ex)
            {
                LOG.Error(ex.Message);
                LOG.Error("Inner Exception: " + ex.InnerException.Message);
            }
        }
    }
}
