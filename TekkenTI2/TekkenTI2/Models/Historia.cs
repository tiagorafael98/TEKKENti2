using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TekkenTI2.Models
{
    public class Historia
    {

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Resumo { get; set; }

        [ForeignKey("Jogo")]
        public int JogoFK { get; set; }
        public virtual Jogo Jogo { get; set; }

    }
}