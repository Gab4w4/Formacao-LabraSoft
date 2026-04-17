using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Projeto
    {
        public Coordenador Coordenador { get; set; }
        public List<Bolsista> Bolsistas { get; set; }
        public string Titulo { get; set; }
        public string AreaDeConhecimento { get; set; }
        public float VerbaAprovada { get; set; }
        public float ValorDeBolsaIndividual { get; set; }
        public Projeto() { 
            Bolsistas = new List<Bolsista>();
        }
    }
}