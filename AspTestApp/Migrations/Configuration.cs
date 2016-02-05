namespace AspTestApp.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<AspTestApp.Models.Database.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AspTestApp.Models.Database.LibraryDbContext";
        }

        protected override void Seed(AspTestApp.Models.Database.LibraryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Books.AddOrUpdate(
                new Book { Name = "TempName1", PageCount = 300, Author = "Igor", ReceivingDate = DateTime.Now },
                new Book { Name = "TempName2", PageCount = 146, Author = "Ivan", ReceivingDate = DateTime.Now },
                new Book { Name = "TempName3", PageCount = 435, Author = "Axe", ReceivingDate = DateTime.Now },
                new Book { Name = "TempName4", PageCount = 42, Author = "Henry", ReceivingDate = DateTime.Now },
                new Book { Name = "TempName5", PageCount = 789, Author = "Field", ReceivingDate = DateTime.Now },
                new Book { Name = "TempName5", PageCount = 234, Author = "Cris", ReceivingDate = DateTime.Now }
            );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
