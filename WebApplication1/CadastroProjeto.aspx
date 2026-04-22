<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroProjeto.aspx.cs" Inherits="WebApplication1.CadastroProjeto" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    <div class="card shadow-sm mx-auto w-100">
        <div class="card-header bg-primary text-white text-center">
            <h2 class="mb-0">📝 Cadastro de Projetos</h2>
        </div>
        
        <div class="card-body p-4">
            <p class="text-muted text-center small">Preencha os campos abaixo para processar o cadastro.</p>
            <hr />

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">Título:</label>
                <asp:TextBox ID="txtTituloProjeto" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group mb-4">
                <label class="form-label font-weight-bold">Área de Conhecimento:</label>
                <asp:TextBox ID="txtAreaDeConhecimento" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>

            <div class="row">
                <div class="col-md-6 form-group mb-3">
                    <label class="form-label font-weight-bold">Verba Aprovada:</label>
                    <asp:TextBox ID="txtVerbaAprovada" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-6 form-group mb-3">
                    <label class="form-label font-weight-bold">Valor da Bolsa Individual:</label>
                    <asp:TextBox ID="txtBolsaIndividual" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div>
                <label class="form-label font-weight-bold">Coordenador: </label>
                <asp:DropDownList ID="ddlListaCoordenadores" CssClass="form-control" runat="server"/>
            </div>
            <br />
            <div>
                <label class="form-label font-weight-bold">Bolsistas: </label>
                <div style="height:150px; overflow-y:auto; border:1px solid #ccc; padding:5px;">
                    <asp:CheckBoxList ID="cblListaBolsistas" runat="server" RepeatLayout="Table" RepeatColumns="8" CellPadding="6" CellSpacing="3" TextAlign="Right"/>

                </div>
            </div>

            <div class="d-grid gap-2">
                <asp:Button ID="btnsalvar" runat="server" text="Salvar e Processar Cadastro" 
                    CssClass="btn btn-success btn-lg w-100" OnClick="btnSalvar_Click" />
                <asp:Button ID="btnlimpar" runat="server" text="Limpar Campos" 
                    CssClass="mt-2 btn btn-outline-secondary btn-lg btn-block" OnClick="btnLimpar_Click" />

            </div>
            <hr />
            <div class="mt-5">
                <h3 class="text-secondary">📋 Lista de Projetos Cadastrados</h3>
         
                <br />

                <asp:GridView ID="gridProjetos" runat="server" 
                    CssClass="table table-hover table-striped border" 
                    AutoGenerateColumns="false" 
                    >
                    <Columns>
                        <asp:BoundField DataField="Titulo" HeaderText="Título" />
                        <asp:BoundField DataField="AreaDeConhecimento" HeaderText="AreaConhecimento" />
                        <asp:BoundField DataField="VerbaAprovada" HeaderText="VerbaAprovada" />
                        <asp:BoundField DataField="ValorDeBolsaIndividual" HeaderText="BolsaIndividual" />

                       

                        <asp:ButtonField 
                            Text="Detalhes"
                            CommandName="Detalhes"
                            ButtonType="Button" />

                        
                    </Columns>
                    <HeaderStyle CssClass="thead-dark" />
                </asp:GridView>

                <asp:Panel ID="panelDetalhes" runat="server" Visible="false">
                    <asp:Literal ID="litDetalhes" runat="server"></asp:Literal>
                </asp:Panel>



                <asp:Label ID="lblAvisoGrid" runat="server" Text="Nenhum projeto na memória." 
                    CssClass=" text-muted italic" Visible="false"></asp:Label>

              


                   
            </div>

            <div class="mt-4 text-center">
                <asp:Label ID="lblMensagem" runat="server" CssClass="h6"></asp:Label>
            </div>
        </div>
    </div>
</div>

</asp:Content>
    

