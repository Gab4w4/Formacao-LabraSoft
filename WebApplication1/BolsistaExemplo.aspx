<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BolsistaExemplo.aspx.cs" Inherits="WebApplication1.BolsistaExemplo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .hero-section {
            background: linear-gradient(135deg, #0d6efd, #0a58ca);
            color: white;
            border-radius: 20px;
            padding: 50px;
            box-shadow: 0 8px 20px rgba(0,0,0,0.15);
        }

            .hero-section h1 {
                font-size: 3rem;
                font-weight: bold;
            }

            .hero-section p {
                font-size: 1.1rem;
                opacity: 0.95;
            }

        .dashboard-card {
            border: none;
            border-radius: 18px;
            transition: 0.3s;
            overflow: hidden;
        }

            .dashboard-card:hover {
                transform: translateY(-5px);
                box-shadow: 0 10px 25px rgba(0,0,0,0.12);
            }

        .dashboard-icon {
            font-size: 3rem;
            margin-bottom: 15px;
        }

        .dashboard-card .card-body {
            padding: 30px;
        }

        .welcome-box {
            background: white;
            border-radius: 18px;
            padding: 30px;
            box-shadow: 0 4px 15px rgba(0,0,0,0.08);
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <div class="hero-section text-center mb-5">

            <h1>🎓 Gestão Acadêmica
            </h1>

            <p class="mt-3">
                Plataforma de gerenciamento de bolsistas, coordenadores, projetos acadêmicos e despesas institucionais.
            </p>

        </div>

        <div class="row">

            <div class="col-md-3 mb-4">

                <div class="card dashboard-card shadow-sm h-100 text-center">

                    <div class="card-body">

                        <div class="dashboard-icon text-primary">
                            👨‍🎓
                        </div>

                        <h5 class="font-weight-bold">Bolsistas
                        </h5>

                        <p class="text-muted">
                            Cadastro e gerenciamento dos alunos vinculados aos projetos.
                        </p>

                        <a href="CadastroBolsista.aspx" class="btn btn-outline-primary btn-sm">Acessar
                        </a>

                    </div>

                </div>

            </div>

            <div class="col-md-3 mb-4">

                <div class="card dashboard-card shadow-sm h-100 text-center">

                    <div class="card-body">

                        <div class="dashboard-icon text-success">
                            👨‍🏫
                        </div>

                        <h5 class="font-weight-bold">Coordenadores
                        </h5>

                        <p class="text-muted">
                            Gerencie professores responsáveis e suas informações acadêmicas.
                        </p>

                        <a href="CadastroCoordenador.aspx" class="btn btn-outline-success btn-sm">Acessar
                        </a>

                    </div>

                </div>

            </div>

            <div class="col-md-3 mb-4">

                <div class="card dashboard-card shadow-sm h-100 text-center">

                    <div class="card-body">

                        <div class="dashboard-icon text-warning">
                            📁
                        </div>

                        <h5 class="font-weight-bold">Projetos
                        </h5>

                        <p class="text-muted">
                            Controle dos projetos acadêmicos e vínculos de bolsistas.
                        </p>

                        <a href="CadastroProjeto.aspx" class="btn btn-outline-warning btn-sm">Acessar
                        </a>

                    </div>

                </div>

            </div>

            <div class="col-md-3 mb-4">

                <div class="card dashboard-card shadow-sm h-100 text-center">

                    <div class="card-body">

                        <div class="dashboard-icon text-danger">
                            💰
                        </div>

                        <h5 class="font-weight-bold">Despesas
                        </h5>

                        <p class="text-muted">
                            Gerencie gastos e despesas relacionadas aos projetos.
                        </p>

                        <a href="CadastroDespesas.aspx" class="btn btn-outline-danger btn-sm">Acessar
                        </a>

                    </div>

                </div>

            </div>

        </div>

        <div class="welcome-box mt-4">

            <h4 class="font-weight-bold text-primary">📌 Sobre o Sistema
            </h4>

            <hr />

            <p class="text-muted mb-0">
                Este sistema foi desenvolvido com o intuito de aplicar os conceitos de C#, ASP.NET, integração com banco de dados e desenvolvimento web, ampliando os conhecimentos dos participantes e contribuindo para a preparação profissional e estágios na área de tecnologia.

            </p>

        </div>

    </div>

</asp:Content>
