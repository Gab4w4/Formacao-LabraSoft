using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Coordenador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Titulacao { get; set; } 
        public string AreaAtuacao { get; set; } 
        public string Email { get; set; }

        public Coordenador()
        {
            this.Titulacao = "Especialista";
        }
    }
}