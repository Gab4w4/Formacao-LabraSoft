using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CadastroDespesas : System.Web.UI.Page
    {
        Repositorio repositorio = new Repositorio();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarProjetos();
        }

        private void CarregarProjetos()
        {
            ddlProjeto.DataSource = repositorio.ListarProjetos();
            ddlProjeto.DataTextField = "Titulo";
            ddlProjeto.DataValueField = "ID";
            ddlProjeto.DataBind();
        }

        private void LimparCampos()
        {
            txtCategoria.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            txtDataDespesa.Text = "";
            ddlProjeto.SelectedIndex = 0;
        }

        protected void btnAdicionarDespesa(object sender, EventArgs e){

            Despesa despesa = new Despesa();
            despesa.Descricao = txtDescricao.Text;
            despesa.Valor = Convert.ToDecimal(txtValor.Text);
            despesa.Categoria = txtCategoria.Text;
            despesa.DataDespesa = DateTime.Parse(txtDataDespesa.Text);
            despesa.ProjetoID = int.Parse(ddlProjeto.SelectedValue);

            repositorio.AdicionarDespesa(despesa);

            LimparCampos();
        }
    }
}