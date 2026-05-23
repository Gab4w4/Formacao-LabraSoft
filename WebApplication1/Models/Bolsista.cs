using System;

namespace WebApplication1.Models
{
    public class Bolsista
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int ProjetoID { get; set; }


        public Bolsista()
        {
            this.DataNascimento = DateTime.Today; 
            this.Sexo = "M";
        }

        public string ObterResumo()
        {
            return $"Bolsista: {Nome} (Matrícula: {Matricula})";
        }

        public int CalcularIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            return idade;
        }
    }
}