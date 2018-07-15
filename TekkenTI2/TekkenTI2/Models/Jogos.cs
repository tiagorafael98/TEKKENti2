using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TekkenTI2.Models
{
    public class Jogos
    {
        public Jogos()
        {

            ListaDePersonagens = new HashSet<Personagens>();
            ListaDeHistorias = new HashSet<Historia>();
            ListaDeComentarios = new HashSet<Comentarios>();
            ListaDePlataformas = new HashSet<Plataformas>();
        }

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Titulo { get; set; }

        public string Genero { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public string Fotografia { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Ano { get; set; }

        public virtual ICollection<Personagens> ListaDePersonagens { get; set; }
        public virtual ICollection<Historia> ListaDeHistorias { get; set; }
        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
        public virtual ICollection<Plataformas> ListaDePlataformas { get; set; }

    }
}