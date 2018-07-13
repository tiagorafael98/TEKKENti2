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
        public System.Data.Entity.DbSet<TekkenTI2.Models.Utilizadores> Utilizadores { get; set; }

        public System.Data.Entity.DbSet<TekkenTI2.Models.Comentarios> Comentarios { get; set; }

        public System.Data.Entity.DbSet<TekkenTI2.Models.Jogos> Jogoes { get; set; }

        // public TekkenDB() : base("DefaultConnection")
        //  { }


    }
}