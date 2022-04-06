using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auvo.Nayckerson.AppClima.WebMVC.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }

        public override string ToString()
        {
            return Nome +"/"+Estado.UF;
        }
    }
}