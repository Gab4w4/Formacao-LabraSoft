using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Projeto
    {   
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string AreaConhecimento { get; set; }

        
        public decimal VerbaAprovada { get; set; }
        public decimal ValorBolsaIndividual { get; set; }
        public decimal Saldo { get; set; }
       
        public Coordenador Responsavel { get; set; } 
        public List<Bolsista> AlunosVinculados { get; set; } 
        public List<Despesa> Despesas { get; set; } 

        public int CoordenadorID { get; set; }

        public Projeto()
        {
            this.AlunosVinculados = new List<Bolsista>();
            this.VerbaAprovada = 0;
        }
    }
}