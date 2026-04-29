using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Repositorio
    {
        public static List<Bolsista> ListaBolsistas = new List<Bolsista>();
        public static List<Coordenador> ListaCoordenadores = new List<Coordenador>();
        public static List<Projeto> ListaProjetos = new List<Projeto>();
        
        
        private string bdConnection = ConfigurationManager.ConnectionStrings["LabraConnection"].ConnectionString;

        public List<Coordenador> ListarCoordernadores(){
            List<Coordenador> coordenadores = new List<Coordenador>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT Id, Nome, CPF, Titulacao, AreaAtuacao, Email FROM Coordenador";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) { 
                    Coordenador c = new Coordenador();
                    c.Id = Convert.ToInt32(reader["ID"]);
                    c.Nome = reader["Nome"].ToString();
                    c.CPF = reader["CPF"].ToString();
                    c.Titulacao = reader["Titulacao"].ToString();
                    c.AreaAtuacao = reader["AreaAtuacao"].ToString();
                    c.Email = reader["Email"].ToString();

                    coordenadores.Add(c);
                }
                
            }return coordenadores;
        }

        public List<Coordenador> BuscarNomeTitulacao(string filtro) {
            List<Coordenador> coordenadores = new List<Coordenador>();


            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT Id, Nome, CPF, Titulacao, AreaAtuacao, Email FROM Coordenador WHERE Nome LIKE @filtro OR Titulacao LIKE @filtro";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Coordenador c = new Coordenador();
                    c.Id = Convert.ToInt32(reader["ID"]);
                    c.Nome = reader["Nome"].ToString();
                    c.CPF = reader["CPF"].ToString();
                    c.Titulacao = reader["Titulacao"].ToString();
                    c.AreaAtuacao = reader["AreaAtuacao"].ToString();
                    c.Email = reader["Email"].ToString();

                    coordenadores.Add(c);
                }

            }return coordenadores;
            
        }

        public void CadastrarCoordernador(Coordenador coordenador)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "INSERT INTO Coordenador(Nome, CPF, Titulacao, AreaAtuacao, Email) VALUES (@Nome, @CPF, @Titulacao, @AreaAtuacao, @Email)";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Nome", coordenador.Nome);
                cmd.Parameters.AddWithValue("@CPF", coordenador.CPF);
                cmd.Parameters.AddWithValue("@Titulacao", coordenador.Titulacao);
                cmd.Parameters.AddWithValue("@AreaAtuacao", coordenador.AreaAtuacao);
                cmd.Parameters.AddWithValue("@Email", coordenador.Email);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
          
        }
    } 
}
