
using PuProject.Migrations;
using PuProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TServices.Models
{
    public class TServicesContext : DbContext
    {
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Gouvernorat> Gouvernorats { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<PublicationClient> PublicationClients { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TServicesContext, Configuration>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }

       
    }
}