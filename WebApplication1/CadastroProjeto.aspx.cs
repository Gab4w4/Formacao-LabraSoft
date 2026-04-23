using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CadastroProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarListas();
                AtualizarGrid();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            // VERIFICAÇÃO DE SEGURANÇA: Se campos básicos estiverem vazios, para aqui.
            if (string.IsNullOrWhiteSpace(txtTituloProjeto.Text) ||
            string.IsNullOrWhiteSpace(txtAreaDeConhecimento.Text) ||
            string.IsNullOrWhiteSpace(txtVerbaAprovada.Text) ||
            string.IsNullOrWhiteSpace(txtBolsaIndividual.Text) ||
            ddlListaCoordenadores.SelectedIndex <= 0 ||
            cblListaBolsistas.Items.Cast<ListItem>().All(i => !i.Selected)
            ) 
            {
                lblMensagem.Text = "⚠️ Por favor, preencha todos os campos corretamente antes de salvar.";
                lblMensagem.CssClass = "alert alert-warning d-block";
                return;
            }
            try
            {
                // 1. Instanciar e preencher o objeto (conforme você já fez)
                Projeto novo = new Projeto();
                novo.Titulo = txtTituloProjeto.Text;
                novo.AreaDeConhecimento = txtAreaDeConhecimento.Text;
                novo.VerbaAprovada = float.Parse(txtVerbaAprovada.Text);
                novo.ValorDeBolsaIndividual = float.Parse(txtBolsaIndividual.Text);
                var coordenador = Repositorio.ListaCoordenadores.FirstOrDefault(c => c.Nome == ddlListaCoordenadores.SelectedItem.Text);
                novo.Coordenador = coordenador;
                foreach(ListItem item in cblListaBolsistas.Items)
                {
                    if (item.Selected)
                    {
                        var bolsista = Repositorio.ListaBolsistas.FirstOrDefault(b => b.Nome == item.Value);
                        if (bolsista != null)
                        {
                            novo.Bolsistas.Add(bolsista);
                        }
                    }

                }

                // 2. ADICIONAR NA LISTA ESTÁTICA
                Repositorio.ListaProjetos.Add(novo);

                // 3. Limpar os campos para o próximo cadastro
                LimparCampos();

                // 4. Mensagem de sucesso e atualizar visualização
                lblMensagem.Text = "Projeto cadastrado com sucesso!";
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

        private void LimparCampos()
        {
            txtTituloProjeto.Text = "";
            txtAreaDeConhecimento.Text = "";
            txtVerbaAprovada.Text = "";
            txtBolsaIndividual.Text = "";
            foreach (ListItem item in cblListaBolsistas.Items)
            {
                item.Selected = false;
            }
            txtTituloProjeto.Focus();
        }

        protected void btnLimpar_Click(Object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void CarregarListas()
        {
            ddlListaCoordenadores.DataSource = Repositorio.ListaCoordenadores;
            ddlListaCoordenadores.DataTextField = "Nome";
            ddlListaCoordenadores.DataBind();

            cblListaBolsistas.DataSource = Repositorio.ListaBolsistas;
            cblListaBolsistas.DataTextField = "Nome";
            cblListaBolsistas.DataBind();
        }

        public void AtualizarGrid()
        {
            if (Repositorio.ListaProjetos.Count > 0)
            {
                gridProjetos.DataSource = Repositorio.ListaProjetos;

                gridProjetos.DataBind();

                lblAvisoGrid.Visible = false;
                gridProjetos.Visible = true;
                
            }
            else
            {
                lblAvisoGrid.Visible = true;
                gridProjetos.Visible = false;
            }
        }

        protected void gridDetalhar_OnClick(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalhes")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                var lista = Repositorio.ListaProjetos;

                Projeto projeto = lista[index];

                panelDetalhes.Visible = true;

                litDetalhes.Text = $@"
                    <div class='row mb-2'>
                        <div class='col-md-6'><b>Título:</b> {projeto.Titulo}</div>
                        <div class='col-md-6'><b>Área:</b> {projeto.AreaDeConhecimento}</div>
                    </div>

                    <div class='row mb-2'>
                        <div class='col-md-6'><b>Coordenador:</b> {projeto.Coordenador.Nome}</div>
                        <div class='col-md-6'><b>Verba:</b> {projeto.VerbaAprovada:C}</div>
                    </div>

                    <div class='row mb-2'>
                        <div class='col-md-6'><b>Bolsa Individual:</b> {projeto.ValorDeBolsaIndividual:C}</div>
                    </div>

                    <div class='mt-3'>
                        <b>Bolsistas:</b><br/>
                        <span class='text-muted'>
                            {string.Join(", ", projeto.Bolsistas.Select(b => b.Nome))}
                        </span>
                    </div>
                ";
            }
        }

        protected void btnFecharDetalhes_Click(object sender, EventArgs e)
        {
            panelDetalhes.Visible = false;
        }
    }
}