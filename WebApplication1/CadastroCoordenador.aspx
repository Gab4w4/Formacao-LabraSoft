<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCoordenador.aspx.cs" Inherits="WebApplication1.CadastroCoordenador" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card shadow-sm mx-auto w-100">
            <div class="card-header bg-dark text-white text-center">
                <h2 class="mb-0">👨‍🏫 Cadastro de Coordenador</h2>
            </div>

            <div class="card-body p-4">
                <div class="form-group mb-3">
                    <label class="form-label font-weight-bold">Nome Completo:</label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Nome do Professor"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col-md-6 form-group mb-3">
                        <label class="form-label font-weight-bold">CPF:</label>
                        <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" placeholder="000.000.000-00"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group mb-3">
                        <label class="form-label font-weight-bold">Titulação:</label>
                        <asp:DropDownList ID="ddlTitulacao" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Selecione..." Value="" />
                            <asp:ListItem Text="Especialista" Value="Especialista" />
                            <asp:ListItem Text="Mestre" Value="Mestre" />
                            <asp:ListItem Text="Doutor" Value="Doutor" />
                            <asp:ListItem Text="Pós-Doutor" Value="Pós-Doutor" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group mb-3">
                    <label class="form-label font-weight-bold">Área de Atuação:</label>
                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" placeholder="Ex: Engenharia de Software"></asp:TextBox>
                </div>

                <div class="form-group mb-4">
                    <label class="form-label font-weight-bold">E-mail Institucional:</label>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="email@instituicao.edu.br"></asp:TextBox>
                </div>

                <div class="d-grid gap-2">
                    <asp:Button ID="btnSalvar" runat="server" Text="Cadastrar Coordenador"
                        CssClass="btn btn-dark btn-lg w-100" OnClick="btnSalvar_Click" />
                </div>

                <asp:Panel ID="plCoordenadores" CssClass="input-group mb-3 mt-3" runat="server">
                    <asp:TextBox ID="txtFiltroNomeTitulacao" runat="server" CssClass="form-control" placeholder="Busque pelo nome ou a titulação"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnFiltroNomeTitulacao" CssClass="btn btn-primary" runat="server" OnClick="btnBuscarNomeTitulacao_Click" Text="Buscar" />
                </asp:Panel>

                
                <asp:Panel ID="plEditarEmail" runat="server" Visible="false">

                    <div class="modal fade show d-block" tabindex="-1" role="dialog" style="background-color: rgba(0,0,0,0.5);">
                        <div class="modal-dialog modal-dialog-centered" role="document">
                            <div class="modal-content shadow-lg">

                                <div class="modal-header bg-primary text-white">
                                    <h5 class="modal-title">✏️ Editar E-mail do Coordenador</h5>

                                    <asp:Button ID="btnCancelar"
                                        runat="server"
                                        Text="X"
                                        CssClass="btn btn-light btn-sm"
                                        OnClick="btnCancelar_Click" />
                                </div>

                                <div class="modal-body">

                                    <label class="font-weight-bold">Novo E-mail:</label>

                                    <asp:TextBox ID="txtEditarEmailCoord"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Digite o novo e-mail">
                                    </asp:TextBox>

                                </div>

                                <div class="modal-footer">

                                    <asp:Button ID="btnSalvarNovoEmail"
                                        runat="server"
                                        CssClass="btn btn-success"
                                        Text="💾 Salvar"
                                        OnClick="btnEditarEmail_Click" />

                                    <asp:Button ID="btnFecharModal"
                                        runat="server"
                                        CssClass="btn btn-secondary"
                                        Text="Cancelar"
                                        OnClick="btnCancelar_Click" />

                                </div>

                            </div>
                        </div>
                    </div>

                </asp:Panel>


                <hr />

                <div class="mt-4">
                    <h4 class="text-secondary">Lista de Coordenadores</h4>
                    <asp:GridView ID="gridCoordenadores" runat="server"
                        CssClass="table table-hover table-bordered shadow-sm mt-3"
                        AutoGenerateColumns="false"
                        DataKeyNames="ID"
                        OnRowCommand="gridCoordenadores_RowCommand">

                        <Columns>

                            <asp:BoundField DataField="ID" HeaderText="ID" />

                            <asp:BoundField DataField="Nome" HeaderText="Nome" />

                            <asp:BoundField DataField="CPF" HeaderText="CPF" />

                            <asp:BoundField DataField="Titulacao" HeaderText="Titulação" />

                            <asp:BoundField DataField="AreaAtuacao" HeaderText="Área de Atuação" />

                            <asp:BoundField DataField="Email" HeaderText="E-mail" />

                            <asp:TemplateField HeaderText="Ações">
                                <ItemTemplate>

                                    <asp:Button ID="btnEditarEmailGrid"
                                        runat="server"
                                        Text="✏️ Editar Email"
                                        CssClass="btn btn-primary btn-sm mr-2"
                                        CommandName="EditarEmail"
                                        CommandArgument='<%# Eval("ID") %>' />

                                    <asp:Button ID="btnExcluirGrid"
                                        runat="server"
                                        Text="🗑 Excluir Coordenador"
                                        CssClass="btn btn-danger btn-sm"
                                        CommandName="ExcluirCoordenador"
                                        CommandArgument='<%# Eval("ID") %>' />

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                        <HeaderStyle CssClass="table-dark" />

                    </asp:GridView>
                    <asp:Label ID="lblAviso" runat="server" Text="Nenhum coordenador cadastrado." CssClass="text-muted small italic"></asp:Label>
                </div>

                <div class="mt-3 text-center">
                    <asp:Label ID="lblMensagem" runat="server" CssClass="h6"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
