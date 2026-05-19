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
        private Repositorio repositorio = new Repositorio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDadosIniciais();
                AtualizarGrid();
            }
        }

        private void CarregarDadosIniciais()
        {
            // Preenche Coordenadores
            ddlCoordenador.DataSource = repositorio.ListarCoordernadores();
            ddlCoordenador.DataTextField = "Nome";
            ddlCoordenador.DataValueField = "ID";
            ddlCoordenador.DataBind();
            ddlCoordenador.Items.Insert(0, new ListItem("Selecione um Coordenador...", ""));

            // Preenche Alunos
            lstAlunos.DataSource = repositorio.ListarBolsistas();
            lstAlunos.DataTextField = "Nome";
            lstAlunos.DataValueField = "ID";
            lstAlunos.DataBind();
        }

        protected void btnSalvarProjeto_Click(object sender, EventArgs e)
        {
            try
            {
                Projeto p = new Projeto();

                // Atributos de Texto
                p.Titulo = txtTitulo.Text;
                p.AreaConhecimento = txtAreaConhecimento.Text;

                // Atributos Financeiros (usando TryParse para evitar erros de digitação)
                decimal verba, valorBolsa;
                decimal.TryParse(txtVerba.Text, out verba);
                decimal.TryParse(txtValorBolsa.Text, out valorBolsa);

                p.VerbaAprovada = verba;
                p.ValorBolsaIndividual = valorBolsa;

                // Relacionamento com Coordenador
           
                p.CoordenadorID = int.Parse(ddlCoordenador.SelectedValue);


                var id_projeto = repositorio.CadastrarProjeto(p);
                
                // Relacionamento com Bolsistas (Lista)
                foreach (ListItem item in lstAlunos.Items)
                {
                    if (item.Selected)
                    {
                        var alunoVinculado = int.Parse(item.Value);
                        repositorio.CadastrarAlunosVinculados(alunoVinculado, id_projeto);
                    }
                }

                // Salvar e atualizar

                
                LimparCampos();
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "❌ Erro ao salvar projeto: " + ex.Message;
                lblMensagem.CssClass = "text-danger d-block mt-2";
            }
        }

        private void LimparCampos()
        {
            txtTitulo.Text = "";
            txtAreaConhecimento.Text = "";
            txtVerba.Text = "";
            txtValorBolsa.Text = "";
            ddlCoordenador.SelectedIndex = 0;
            lstAlunos.ClearSelection();
        }

        private void AtualizarGrid()
        {
            gridProjetos.DataSource = repositorio.ListarProjetos();
            gridProjetos.DataBind();
        }

        protected void gridProjetos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalhes")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idProjeto = Convert.ToInt32(gridProjetos.DataKeys[index].Value);

                var projeto = repositorio.BuscarProjetoId(idProjeto);
                
                
                if (projeto != null) {

                    // Preenche campos básicos
                    litTituloDet.Text = projeto.Titulo;
                    lblCoordDet.Text = projeto.Responsavel?.Nome ?? "Não definido";
                    lblTitDet.Text = projeto.Responsavel?.Titulacao;
                    lblVerbaDet.Text = projeto.VerbaAprovada.ToString("C");
                    lblBolsaDet.Text = projeto.ValorBolsaIndividual.ToString("C"); // Novo campo
                    lblAreaDet.Text = projeto.AreaConhecimento;

                    var alunos = repositorio.listarBolsistasProjeto(idProjeto);
                    
                    
                    // Preenche o Repeater com a lista de bolsistas
                    if (alunos.Count > 0)
                    {
                        rptBolsistasDet.DataSource = alunos;
                        rptBolsistasDet.DataBind();
                        rptBolsistasDet.Visible = true;
                        lblSemBolsistas.Visible = false;
                    }
                    else
                    {
                        rptBolsistasDet.Visible = false;
                        lblSemBolsistas.Visible = true;
                    }

                    var despesas = repositorio.listarDespesas(idProjeto);
                    if (despesas.Count > 0)
                    {
                        rptDespesas.DataSource = despesas;
                        rptDespesas.DataBind();
                        rptDespesas.Visible = true;
                        lblSemDespesas.Visible = false;
                    }
                    else
                    {
                        rptDespesas.Visible = false;
                        lblSemDespesas.Visible = true;
                    }

                }


                pnlDetalhes.Visible = true;
            }
        }

        // Botão para esconder o painel novamente
        protected void btnFechar_Click(object sender, EventArgs e)
        {
            pnlDetalhes.Visible = false;
        }
    }
}