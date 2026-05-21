using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace WebApplication1.Models
{
    public class Repositorio
    {
        public static List<Bolsista> ListaBolsistas = new List<Bolsista>();
        public static List<Coordenador> ListaCoordenadores = new List<Coordenador>();
        public static List<Projeto> ListaProjetos = new List<Projeto>();


        private string bdConnection = ConfigurationManager.ConnectionStrings["LabraConnection"].ConnectionString;

        public List<Coordenador> ListarCoordernadores()
        {
            List<Coordenador> coordenadores = new List<Coordenador>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT Id, Nome, CPF, Titulacao, AreaAtuacao, Email FROM Coordenador";
                SqlCommand cmd = new SqlCommand(sql, connection);
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

            }
            return coordenadores;
        }

        public List<Coordenador> BuscarNomeTitulacao(string filtro)
        {
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

            }
            return coordenadores;

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

        public void ExcluirCoordenador(int idCoordenador)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "DELETE FROM Coordenador WHERE ID = @idCoordenador";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@idCoordenador", idCoordenador);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditarEmailCord(int idCoordenador, String emailNovo)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "UPDATE Coordenador SET email = @emailNovo WHERE ID = @idCoordenador";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@emailNovo", emailNovo);
                cmd.Parameters.AddWithValue("@idCoordenador", idCoordenador);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Bolsista> ListarBolsistas()
        {
            List<Bolsista> bolsistas = new List<Bolsista>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT Id, Nome, CPF, Matricula, Sexo, DataNascimento FROM Bolsista";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bolsista b = new Bolsista();
                    b.ID = Convert.ToInt32(reader["ID"]);
                    b.Nome = reader["Nome"].ToString();
                    b.CPF = reader["CPF"].ToString();
                    b.Matricula = reader["Matricula"].ToString();
                    b.Sexo = reader["Sexo"].ToString();
                    b.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);

                    bolsistas.Add(b);
                }

            }
            return bolsistas;
        }

        public void CadastrarBolsista(Bolsista bolsista)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "INSERT INTO Bolsista(Nome, CPF, Matricula, Sexo, DataNascimento) VALUES (@Nome, @CPF, @Matricula, @Sexo, @DataNascimento)";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Nome", bolsista.Nome);
                cmd.Parameters.AddWithValue("@CPF", bolsista.CPF);
                cmd.Parameters.AddWithValue("@Matricula", bolsista.Matricula);
                cmd.Parameters.AddWithValue("@Sexo", bolsista.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", bolsista.DataNascimento);

                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<Bolsista> FiltrarMulheres()
        {
            List<Bolsista> bolsistas = new List<Bolsista>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT Id, Nome, CPF, Matricula, Sexo, DataNascimento FROM Bolsista WHERE Sexo = 'F'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bolsista b = new Bolsista();
                    b.ID = Convert.ToInt32(reader["ID"]);
                    b.Nome = reader["Nome"].ToString();
                    b.CPF = reader["CPF"].ToString();
                    b.Matricula = reader["Matricula"].ToString();
                    b.Sexo = reader["Sexo"].ToString();
                    b.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);

                    bolsistas.Add(b);
                }

            }
            return bolsistas;

        }
        public List<Bolsista> OrdemAlfabeticaBolsistas()
        {
            List<Bolsista> bolsistas = new List<Bolsista>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT Id, Nome, CPF, Matricula, Sexo, DataNascimento FROM Bolsista ORDER BY Nome ASC";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bolsista b = new Bolsista();
                    b.ID = Convert.ToInt32(reader["ID"]);
                    b.Nome = reader["Nome"].ToString();
                    b.CPF = reader["CPF"].ToString();
                    b.Matricula = reader["Matricula"].ToString();
                    b.Sexo = reader["Sexo"].ToString();
                    b.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);

                    bolsistas.Add(b);
                }

            }
            return bolsistas;

        }

        //AQUI PRECISA FAZER JOIN COM TABELA DE COORDENADOR PARA PEGAR O NM DO COORDENADOR.
        public List<Projeto> ListarProjetos()
        {
            List<Projeto> projetos = new List<Projeto>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT ID, Titulo, AreaConhecimento, VerbaAprovada, ValorBolsaIndividual FROM Projeto";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Projeto p = new Projeto();
                    p.ID = Convert.ToInt32(reader["ID"]);
                    p.Titulo = reader["Titulo"].ToString();
                    p.AreaConhecimento = reader["AreaConhecimento"].ToString();
                    p.VerbaAprovada = Convert.ToDecimal(reader["VerbaAprovada"]);
                    p.ValorBolsaIndividual = Convert.ToDecimal(reader["ValorBolsaIndividual"]);

                    projetos.Add(p);
                }

            }
            return projetos;
        }

        public int CadastrarProjeto(Projeto projeto)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "INSERT INTO Projeto(Titulo, AreaConhecimento, VerbaAprovada, ValorBolsaIndividual, CoordenadorID)OUTPUT INSERTED.ID VALUES (@Titulo, @AreaConhecimento, @VerbaAprovada, @ValorBolsaIndividual, @CoordenadorID)";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Titulo", projeto.Titulo);
                cmd.Parameters.AddWithValue("@AreaConhecimento", projeto.AreaConhecimento);
                cmd.Parameters.AddWithValue("@VerbaAprovada", projeto.VerbaAprovada);
                cmd.Parameters.AddWithValue("@ValorBolsaIndividual", projeto.ValorBolsaIndividual);
                cmd.Parameters.AddWithValue("@CoordenadorID", projeto.CoordenadorID);

                connection.Open();
                return (int) cmd.ExecuteScalar();
            }
        }

        public void CadastrarAlunosVinculados(int id_bolsista, int id_projeto)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "INSERT INTO ProjetoBolsista(ProjetoID, BolsistaID) VALUES (@id_projeto, @id_bolsista)";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@id_projeto", id_projeto);
                cmd.Parameters.AddWithValue("@id_bolsista", id_bolsista);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AdicionarDespesa(Despesa despesa)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "INSERT INTO Despesa(Descricao, Valor, DataDespesa, Categoria, ProjetoID) VALUES (@Descricao, @Valor, @DataDespesa, @Categoria, @ProjetoID)";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                cmd.Parameters.AddWithValue("@Valor", despesa.Valor);
                cmd.Parameters.AddWithValue("@DataDespesa", despesa.DataDespesa);
                cmd.Parameters.AddWithValue("@Categoria", despesa.Categoria);
                cmd.Parameters.AddWithValue("@ProjetoID", despesa.ProjetoID);

                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public Projeto BuscarProjetoId(int id)
        {
            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT P.*, C.Nome, C.Titulacao FROM Projeto P INNER JOIN Coordenador C ON P.CoordenadorID = C.ID WHERE P.ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@ID", id);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) {
                    return new Projeto
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Titulo = reader["Titulo"].ToString(),
                        AreaConhecimento = reader["AreaConhecimento"].ToString(),
                        VerbaAprovada = Convert.ToDecimal(reader["VerbaAprovada"]),
                        ValorBolsaIndividual = Convert.ToDecimal(reader["ValorBolsaIndividual"]),
                        Responsavel = new Coordenador
                        {
                            Nome = reader["Nome"].ToString(),
                            Titulacao = reader["Titulacao"].ToString()
                        }

                    };
                }
            }return null;
        }

        public List<Bolsista> listarBolsistasProjeto(int pID)
        {
            List<Bolsista> bolsistas = new List<Bolsista>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT B.Nome, B.CPF, B.Sexo FROM Bolsista B INNER JOIN ProjetoBolsista PB ON B.ID = PB.BolsistaID WHERE PB.ProjetoID = @pID";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@pID", pID);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bolsistas.Add(new Bolsista
                    {
                        Nome = reader["Nome"].ToString(),
                        CPF = reader["CPF"].ToString(),
                        Sexo = reader["Sexo"].ToString()
                    });
                }

            }return bolsistas;
        }

        public List<Despesa> listarDespesas(int pID)
        {
            List<Despesa> despesas = new List<Despesa>();

            using (SqlConnection connection = new SqlConnection(bdConnection))
            {
                string sql = "SELECT Descricao, Valor, DataDespesa, Categoria FROM Despesa WHERE ProjetoID = @pID";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@pID", pID);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    despesas.Add(new Despesa
                    {
                        Descricao = reader["Descricao"].ToString(),
                        Valor = Convert.ToDecimal(reader["Valor"]),
                        DataDespesa = Convert.ToDateTime(reader["DataDespesa"]),
                        Categoria = reader["Categoria"].ToString()
                    });
                }

            }
            return despesas;
        }

    }
}
