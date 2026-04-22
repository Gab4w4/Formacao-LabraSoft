<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCoordenador.aspx.cs" Inherits="WebApplication1.CadastroCoordenador" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card shadow-sm mx-auto w-100">
            <div class="card-header bg-primary text-white text-center">
                <h2 class="mb-0">📝 Cadastro de Coordernadores</h2>
            </div>
        
            <div class="card-body p-4">
                <p class="text-muted text-center small">Preencha os campos abaixo para processar o cadastro.</p>
                <hr />

                <div class="form-group mb-3">
                    <label class="form-label font-weight-bold">Nome Completo:</label>
                    <asp:TextBox ID="txtNomeCoord" runat="server" CssClass="form-control" placeholder="Ex: João Silva"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col-md-6 form-group mb-3">
                        <label class="form-label font-weight-bold">Titulação:</label>
                        <asp:TextBox ID="txtTitulacao" runat="server" CssClass="form-control" placeholder="Ex: Doutor"></asp:TextBox>
                    </div>

                    <div class="col-md-6 form-group mb-3">
                        <label class="form-label font-weight-bold">CPF:</label>
                        <asp:TextBox ID="txtCPFCoord" runat="server" CssClass="form-control" placeholder="000.000.000-00"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group mb-4">
                    <label class="form-label font-weight-bold">Área de Atuação:</label>
                    <asp:TextBox ID="txtAreaDeAtuacao" runat="server" CssClass="form-control" placeholder="Ex: Engenharia"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label class="form-label font-weight-bold">Email:</label>
                    <asp:TextBox ID="txtEmailCoord" runat="server" CssClass="form-control" placeholder="seuemail@exemplo.com.br"></asp:TextBox>
                </div>


                <div class="d-grid gap-2">
                    <asp:Button ID="btnSalvarCoord" runat="server" Text="Salvar e Processar Cadastro" 
                        CssClass="btn btn-success btn-lg w-100" OnClick="btnSalvar_Click" />
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar Campos" 
                        CssClass="mt-2 btn btn-outline-secondary btn-lg btn-block" OnClick="btnLimpar_Click" />

                </div>
                <hr />
                <div class="mt-5">
                    <h3 class="text-secondary">📋 Lista de Coordenadores Cadastrados</h3>
                    <asp:Panel ID="plCoordenadores" CssClass="input-group mb-3" runat="server">
                        <asp:TextBox ID="txtFiltroNomeTitulacao" runat="server" CssClass="form-control" placeholder="Busque pelo nome ou a titulação"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnFiltroNomeTitulacao" CssClass="btn btn-primary" runat="server" OnClick="btnBuscarNomeTitulacao_Click" Text="Buscar" />
                    </asp:Panel> 

                    <asp:GridView ID="gridCoordenadores" runat="server" 
                        CssClass="table table-hover table-striped border" 
                        AutoGenerateColumns="true" 
                        GridLines="None">
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>

                    <asp:Label ID="lblAvisoGrid" runat="server" Text="Nenhum coordenador na memória." 
                        CssClass=" text-muted italic" Visible="false"></asp:Label>
                </div>

                <div class="mt-4 text-center">
                    <asp:Label ID="lblMensagem" runat="server" CssClass="h6"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
