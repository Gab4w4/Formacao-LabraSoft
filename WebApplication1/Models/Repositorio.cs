using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Repositorio
    {
        public static List<Bolsista> ListaBolsistas = new List<Bolsista>(){
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

        public static List<Coordenador> ListaCoordenadores = new List<Coordenador>()
        {
            new Coordenador
            {
                Id = 1,
                Nome = "Ana Souza",
                CPF = "123.456.789-00",
                Titulacao = "Doutora",
                AreaAtuacao = "Engenharia de Software",
                Email = "ana.souza@exemplo.com"
            },
            new Coordenador
            {
                Id = 2,
                Nome = "Carlos Lima",
                CPF = "234.567.890-11",
                Titulacao = "Mestre",
                AreaAtuacao = "Banco de Dados",
                Email = "carlos.lima@exemplo.com"
            },
            new Coordenador
            {
                Id = 3,
                Nome = "Mariana Oliveira",
                CPF = "345.678.901-22",
                Titulacao = "Doutora",
                AreaAtuacao = "Inteligência Artificial",
                Email = "mariana.oliveira@exemplo.com"
            },
            new Coordenador
            {
                Id = 4,
                Nome = "João Pereira",
                CPF = "456.789.012-33",
                Titulacao = "Especialista",
                AreaAtuacao = "Redes de Computadores",
                Email = "joao.pereira@exemplo.com"
            },
            new Coordenador
            {
                Id = 5,
                Nome = "Fernanda Costa",
                CPF = "567.890.123-44",
                Titulacao = "Mestre",
                AreaAtuacao = "Segurança da Informação",
                Email = "fernanda.costa@exemplo.com"
            },
            new Coordenador
            {
                Id = 6,
                Nome = "Ricardo Alves",
                CPF = "678.901.234-55",
                Titulacao = "Doutor",
                AreaAtuacao = "Sistemas Distribuídos",
                Email = "ricardo.alves@exemplo.com"
            },
            new Coordenador
            {
                Id = 7,
                Nome = "Juliana Martins",
                CPF = "789.012.345-66",
                Titulacao = "Especialista",
                AreaAtuacao = "Desenvolvimento Web",
                Email = "juliana.martins@exemplo.com"
            },
            new Coordenador
            {
                Id = 8,
                Nome = "Bruno Rocha",
                CPF = "890.123.456-77",
                Titulacao = "Mestre",
                AreaAtuacao = "Computação em Nuvem",
                Email = "bruno.rocha@exemplo.com"
            },
            new Coordenador
            {
                Id = 9,
                Nome = "Patrícia Gomes",
                CPF = "901.234.567-88",
                Titulacao = "Doutora",
                AreaAtuacao = "Ciência de Dados",
                Email = "patricia.gomes@exemplo.com"
            },
            new Coordenador
            {
                Id = 10,
                Nome = "Eduardo Nunes",
                CPF = "012.345.678-99",
                Titulacao = "Especialista",
                AreaAtuacao = "Arquitetura de Software",
                Email = "eduardo.nunes@exemplo.com"
            }
                };

        public static List<Projeto> ListaProjetos = new List<Projeto>();
    }
}