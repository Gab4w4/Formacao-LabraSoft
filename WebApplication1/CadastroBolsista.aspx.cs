using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models; // Garante que o C# ache sua classe

namespace WebApplication1
{
    public partial class CadastroBolsista : System.Web.UI.Page
    {

        private static List<Bolsista> listaBolsistas = new List<Bolsista>(){
            new Bolsista { Nome = "Romário Souza", CPF = "010.010.010-11", Matricula = "B0011", DataNascimento = new DateTime(2006, 08, 08), Sexo = "M"},
            new Bolsista { Nome = "Ana Souza", CPF = "111.111.111-11", Matricula = "B001", DataNascimento = new DateTime(2000, 5, 10), Sexo = "F" },
            new Bolsista { Nome = "Bruno Lima", CPF = "222.222.222-22", Matricula = "B002", DataNascimento = new DateTime(1999, 8, 20), Sexo = "M" },
            new Bolsista { Nome = "Carla Mendes", CPF = "333.333.333-33", Matricula = "B003", DataNascimento = new DateTime(2001, 2, 15), Sexo = "F" },
            new Bolsista { Nome = "Daniel Rocha", CPF = "444.444.444-44", Matricula = "B004", DataNascimento = new DateTime(1998, 12, 1), Sexo = "M" },
            new Bolsista { Nome = "Eduarda Alves", CPF = "555.555.555-55", Matricula = "B005", DataNascimento = new DateTime(2002, 7, 30), Sexo = "F" },
            new Bolsista { Nome = "Felipe Santos", CPF = "666.666.666-66", Matricula = "B006", DataNascimento = new DateTime(2000, 3, 25), Sexo = "M" },
            new Bolsista { Nome = "Gabriela Costa", CPF = "777.777.777-77", Matricula = "B007", DataNascimento = new DateTime(2001, 11, 5), Sexo = "F" },
            new Bolsista { Nome = "Henrique Martins", CPF = "888.888.888-88", Matricula = "B008", DataNascimento = new DateTime(1997, 6, 18), Sexo = "M" },
            new Bolsista { Nome = "Isabela Ferreira", CPF = "999.999.999-99", Matricula = "B009", DataNascimento = new DateTime(2003, 9, 9), Sexo = "F" },
            new Bolsista { Nome = "João Pereira", CPF = "000.000.000-00", Matricula = "B010", DataNascimento = new DateTime(1999, 1, 12), Sexo = "M" }
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
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
            string.IsNullOrWhiteSpace(txtMatricula.Text) ||
            string.IsNullOrWhiteSpace(txtCPF.Text) ||
            string.IsNullOrWhiteSpace(txtDataNasc.Text) ||
            ddlSexo.SelectedIndex <= 0)
            {
                lblMensagem.Text = "⚠️ Por favor, preencha todos os campos corretamente antes de salvar.";
                lblMensagem.CssClass = "alert alert-warning d-block";
                return;
            }
            try
            {
                // 1. Instanciar e preencher o objeto (conforme você já fez)
                Bolsista novo = new Bolsista();
                novo.Nome = txtNome.Text;
                novo.Matricula = txtMatricula.Text;
                novo.CPF = txtCPF.Text;
                novo.Sexo = ddlSexo.SelectedValue;
                novo.DataNascimento = DateTime.Parse(txtDataNasc.Text);

                //1.5 Lógica provisória para não cadastrar o mesmo usuário duas vezes
                if (listaBolsistas.Any(b => b.CPF == txtCPF.Text))
                {
                    lblMensagem.Text = "⚠️ Este bolsista já foi cadastrado!";
                    lblMensagem.CssClass = "alert alert-warning d-block";
                    LimparCampos();
                    AtualizarGrid();
                    return; // Para a execução aqui
                }

                // 2. ADICIONAR NA LISTA ESTÁTICA
                listaBolsistas.Add(novo);

                // 3. Limpar os campos para o próximo cadastro
                LimparCampos();

                // 4. Mensagem de sucesso e atualizar visualização
                lblMensagem.Text = "Bolsista cadastrado com sucesso!";
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
            txtNome.Text = "";
            txtMatricula.Text = "";
            txtCPF.Text = "";
            txtDataNasc.Text = "";
            ddlSexo.SelectedIndex = 0;
            txtNome.Focus(); // Coloca o cursor de volta no Nome
        }

        private void AtualizarGrid()
        {
            if (listaBolsistas.Count > 0)
            {
                // 1. Dizemos ao Grid qual é a fonte de dados (nossa lista)
                gridBolsistas.DataSource = listaBolsistas;

                // 2. O DataBind() "desenha" as linhas da tabela no HTML
                gridBolsistas.DataBind();

                lblAvisoGrid.Visible = false;
                gridBolsistas.Visible = true;
                plButtonFiltro.Visible = true;
            }
            else
            {
                plButtonFiltro.Visible=false;
                lblAvisoGrid.Visible = true;
                gridBolsistas.Visible = false;
            }
        }

        protected void btnRecarregarLista_Click(object sender, EventArgs e)
        {
            gridBolsistas.DataSource= listaBolsistas;
            gridBolsistas.DataBind();
        }
            
        protected void btnFiltrarMulheres_Click(object sender, EventArgs e)
        {
            gridBolsistas.DataSource = listaBolsistas.Where(x => x.Sexo == "F").ToList();
            gridBolsistas.DataBind();
        }

        protected void btnOrdemAlfabetica_Click(object sender, EventArgs e)
        {
            gridBolsistas.DataSource = listaBolsistas.OrderBy(x => x.Nome).ToList();
            gridBolsistas.DataBind();
        }
    }
}
