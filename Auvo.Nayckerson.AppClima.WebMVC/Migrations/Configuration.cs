namespace Auvo.Nayckerson.AppClima.WebMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Auvo.Nayckerson.AppClima.WebMVC.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.Context context)
        {
            
        }
    }
}
