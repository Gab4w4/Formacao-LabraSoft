using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CadastroCoordenador : System.Web.UI.Page
    {
        private Repositorio repositorio = new Repositorio();
        // Lista estática para manter os dados em memória durante a execução
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                
                AtualizarGrid();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
            string.IsNullOrWhiteSpace(txtCPF.Text) ||
            string.IsNullOrWhiteSpace(txtArea.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            ddlTitulacao.SelectedIndex <= 0)
            {
                lblMensagem.Text = "⚠️ Por favor, preencha todos os campos corretamente antes de salvar.";
                lblMensagem.CssClass = "alert alert-warning d-block";
                return;
            }
            try
            {
                Coordenador novo = new Coordenador();
                novo.Nome = txtNome.Text;
                novo.CPF = txtCPF.Text;
                novo.Titulacao = ddlTitulacao.SelectedValue;
                novo.AreaAtuacao = txtArea.Text;
                novo.Email = txtEmail.Text;

                repositorio.CadastrarCoordernador(novo);
               

                LimparCampos();
                lblMensagem.Text = "Coordenador salvo com sucesso!";
                lblMensagem.CssClass = "text-success";

                AtualizarGrid();
                
            }
            catch (Exception)
            {
                lblMensagem.Text = "Erro ao salvar coordenador.";
                lblMensagem.CssClass = "text-danger";
            }
        }

        

        private void AtualizarGrid()
        {
            var listaCoordenadores = repositorio.ListarCoordernadores();
            if (listaCoordenadores.Count > 0)
            {
                gridCoordenadores.DataSource = listaCoordenadores;
                gridCoordenadores.DataBind();
                lblAviso.Visible = false;
            }
            else
            {
                lblAviso.Visible = true;
            }
        }

        protected void gridCoordenadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCoordenador = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ExcluirCoordenador")
            {
                try
                {
                    repositorio.ExcluirCoordenador(idCoordenador);

                    AtualizarGrid();

                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "sucesso",
                        "alert('Coordenador excluído com sucesso!');",
                        true
                    );
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "erro",
                        "alert('Não é possível excluir este coordenador, pois ele está vinculado a um projeto atualmente.');",
                        true
                    );
                }
            }

            if (e.CommandName == "EditarEmail")
            {
                ViewState["IdCoordenadorEditar"] = idCoordenador;

                txtEditarEmailCoord.Text = "";

                plEditarEmail.Visible = true;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtArea.Text = "";
            txtEmail.Text = "";
            ddlTitulacao.SelectedIndex = 0;
            txtNome.Focus();
        }

        protected void btnBuscarNomeTitulacao_Click(object sender, EventArgs e)
        {
            string filtroNomeTitulacao = txtFiltroNomeTitulacao.Text;
            var listaCoordenadores = repositorio.BuscarNomeTitulacao(filtroNomeTitulacao);

            txtFiltroNomeTitulacao.Text = "";

            gridCoordenadores.DataSource = listaCoordenadores;
            gridCoordenadores.DataBind();
        }

        

        protected void btnCancelar_Click (object sender, EventArgs e)
        {
            plEditarEmail.Visible = false;
        }

        protected void btnEditarEmail_Click(Object sender, EventArgs e)
        {
            var idCoordenador = (int)ViewState["IdCoordenadorEditar"];

            var emailNovo = txtEditarEmailCoord.Text;

            repositorio.EditarEmailCord(idCoordenador, emailNovo);

            plEditarEmail.Visible = false;

            AtualizarGrid();
        }


    }
}