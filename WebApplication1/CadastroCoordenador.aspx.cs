using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CadastroCoordenador : System.Web.UI.Page
    {
        private static List<Coordenador> listaCoordenadores = new List<Coordenador>()
        {
            new Coordenador
            {
                Id = 1,
                Nome = "Ana Souza",
                CPF = "123.456.789-00",
                Titulacao = "Doutora",
                AreaAtuacao = "Engenharia de Software",
                Email = "ana.souza@exemplo.com"
            },
            new Coordenador
            {
                Id = 2,
                Nome = "Carlos Lima",
                CPF = "234.567.890-11",
                Titulacao = "Mestre",
                AreaAtuacao = "Banco de Dados",
                Email = "carlos.lima@exemplo.com"
            },
            new Coordenador
            {
                Id = 3,
                Nome = "Mariana Oliveira",
                CPF = "345.678.901-22",
                Titulacao = "Doutora",
                AreaAtuacao = "Inteligência Artificial",
                Email = "mariana.oliveira@exemplo.com"
            },
            new Coordenador
            {
                Id = 4,
                Nome = "João Pereira",
                CPF = "456.789.012-33",
                Titulacao = "Especialista",
                AreaAtuacao = "Redes de Computadores",
                Email = "joao.pereira@exemplo.com"
            },
            new Coordenador
            {
                Id = 5,
                Nome = "Fernanda Costa",
                CPF = "567.890.123-44",
                Titulacao = "Mestre",
                AreaAtuacao = "Segurança da Informação",
                Email = "fernanda.costa@exemplo.com"
            },
            new Coordenador
            {
                Id = 6,
                Nome = "Ricardo Alves",
                CPF = "678.901.234-55",
                Titulacao = "Doutor",
                AreaAtuacao = "Sistemas Distribuídos",
                Email = "ricardo.alves@exemplo.com"
            },
            new Coordenador
            {
                Id = 7,
                Nome = "Juliana Martins",
                CPF = "789.012.345-66",
                Titulacao = "Especialista",
                AreaAtuacao = "Desenvolvimento Web",
                Email = "juliana.martins@exemplo.com"
            },
            new Coordenador
            {
                Id = 8,
                Nome = "Bruno Rocha",
                CPF = "890.123.456-77",
                Titulacao = "Mestre",
                AreaAtuacao = "Computação em Nuvem",
                Email = "bruno.rocha@exemplo.com"
            },
            new Coordenador
            {
                Id = 9,
                Nome = "Patrícia Gomes",
                CPF = "901.234.567-88",
                Titulacao = "Doutora",
                AreaAtuacao = "Ciência de Dados",
                Email = "patricia.gomes@exemplo.com"
            },
            new Coordenador
            {
                Id = 10,
                Nome = "Eduardo Nunes",
                CPF = "012.345.678-99",
                Titulacao = "Especialista",
                AreaAtuacao = "Arquitetura de Software",
                Email = "eduardo.nunes@exemplo.com"
            }
                };
            
            
         
        protected void Page_Load(object sender, EventArgs e)
        {
            // Na primeira vez que a página carrega, podemos querer exibir a lista 
            if (!IsPostBack)
            {
                AtualizarGrid();

            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            // VERIFICAÇÃO DE SEGURANÇA: Se campos básicos estiverem vazios, para aqui.
            if (string.IsNullOrWhiteSpace(txtNomeCoord.Text) ||
            string.IsNullOrWhiteSpace(txtTitulacao.Text) ||
            string.IsNullOrWhiteSpace(txtCPFCoord.Text) ||
            string.IsNullOrWhiteSpace(txtAreaDeAtuacao.Text) ||
            string.IsNullOrWhiteSpace(txtEmailCoord.Text))
            {
                lblMensagem.Text = "⚠️ Por favor, preencha todos os campos corretamente antes de salvar.";
                lblMensagem.CssClass = "alert alert-warning d-block";
                return;
            }
            try
            {
                // 1. Instanciar e preencher o objeto (conforme você já fez)
                Coordenador novo = new Coordenador();
                novo.Nome = txtNomeCoord.Text;
                novo.Titulacao = txtTitulacao.Text;
                novo.CPF = txtCPFCoord.Text;
                novo.AreaAtuacao = txtAreaDeAtuacao.Text;
                novo.Email = txtEmailCoord.Text;

                //1.5 Lógica provisória para não cadastrar o mesmo usuário duas vezes
                if (listaCoordenadores.Any(b => b.CPF == txtCPFCoord.Text))
                {
                    lblMensagem.Text = "⚠️ Este Coordenador já foi cadastrado!";
                    lblMensagem.CssClass = "alert alert-warning d-block";
                    LimparCampos();
                    AtualizarGrid();
                    return; // Para a execução aqui
                }

                // 2. ADICIONAR NA LISTA ESTÁTICA
                listaCoordenadores.Add(novo);

                // 3. Limpar os campos para o próximo cadastro
                LimparCampos();

                // 4. Mensagem de sucesso e atualizar visualização
                lblMensagem.Text = "Coordenador cadastrado com sucesso!";
                lblMensagem.CssClass = "alert alert-success d-block";

                // Chamar o método que atualiza o GridView (veremos abaixo)
                AtualizarGrid();
            }
            catch (Exception)
            {
                lblMensagem.Text = "Erro ao cadastrar. Verifique os dados.";
                lblMensagem.CssClass = "alert alert-danger d-block";
            }
        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();

            // Aproveite para limpar a mensagem de erro/sucesso também
            lblMensagem.Text = "";
            lblMensagem.CssClass = "";
        }

        private void LimparCampos()
        {
            txtNomeCoord.Text = "";
            txtTitulacao.Text = "";
            txtCPFCoord.Text = "";
            txtAreaDeAtuacao.Text = "";
            txtEmailCoord.Text = "";
            txtNomeCoord.Focus(); // Coloca o cursor de volta no Nome
        }

        private void AtualizarGrid()
        {
            if (listaCoordenadores.Count > 0)
            {
                // 1. Dizemos ao Grid qual é a fonte de dados (nossa lista)
                gridCoordenadores.DataSource = listaCoordenadores;

                // 2. O DataBind() "desenha" as linhas da tabela no HTML
                gridCoordenadores.DataBind();

                lblAvisoGrid.Visible = false;
                gridCoordenadores.Visible = true;
               
            }
            else
            {
                
                lblAvisoGrid.Visible = true;
                gridCoordenadores.Visible = false;
            }
        }


        protected void btnBuscarNomeTitulacao_Click(object sender, EventArgs e) {
            gridCoordenadores.DataSource = listaCoordenadores.Where(c => c.Nome.Contains(txtFiltroNomeTitulacao.Text) || c.Titulacao.Contains(txtFiltroNomeTitulacao.Text)).ToList();
            gridCoordenadores.DataBind();
        } 
    }
}