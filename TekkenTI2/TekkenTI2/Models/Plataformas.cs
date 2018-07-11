using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TekkenTI2.Models
{
    public class Plataformas
    {
        public Plataformas()
        {
            ListaDeJogos = new HashSet<Jogo>();
        }

        [Key]
        public int ID { get; set; }

        public string Jogo { get; set; }

        public string Plataforma { get; set; }

        public string Ano { get; set; }

        public virtual ICollection<Jogo> ListaDeJogos { get; set; }

    }
}