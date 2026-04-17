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
                if (Repositorio.ListaCoordenadores.Any(b => b.CPF == txtCPFCoord.Text))
                {
                    lblMensagem.Text = "⚠️ Este Coordenador já foi cadastrado!";
                    lblMensagem.CssClass = "alert alert-warning d-block";
                    LimparCampos();
                    AtualizarGrid();
                    return; // Para a execução aqui
                }

                // 2. ADICIONAR NA LISTA ESTÁTICA
                Repositorio.ListaCoordenadores.Add(novo);

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
            if (Repositorio.ListaCoordenadores.Count > 0)
            {
                // 1. Dizemos ao Grid qual é a fonte de dados (nossa lista)
                gridCoordenadores.DataSource = Repositorio.ListaCoordenadores;

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
            gridCoordenadores.DataSource = Repositorio.ListaCoordenadores.Where(c => c.Nome.Contains(txtFiltroNomeTitulacao.Text) || c.Titulacao.Contains(txtFiltroNomeTitulacao.Text)).ToList();
            gridCoordenadores.DataBind();
        } 
    }
}