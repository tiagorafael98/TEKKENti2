using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TekkenTI2.Models;

namespace TekkenTI2.Models
{
    public class TekkenDB : DbContext
    {

        public TekkenDB() : base("DefaultConnection")
        { }

        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<Historia> Historia { get; set; }
        public virtual DbSet<Personagens> Personagens { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}