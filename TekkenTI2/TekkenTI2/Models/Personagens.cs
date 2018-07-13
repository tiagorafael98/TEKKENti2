using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TekkenTI2.Models
{
    public class Personagens
    {
        public Personagens()
        {
            ListaDeJogos = new HashSet<Jogos>();
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public string Origem { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public string Estreia { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string TipoLuta { get; set; }

        public string Fotografia { get; set; }

        public virtual ICollection<Jogos> ListaDeJogos { get; set; }
        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }

    }
}