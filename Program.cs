using System;
using System.Threading;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@$"
=======================================
│        Menu de cadastro para        │
│     pessoas Físicas e Jurídicas     │
=======================================
            ");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Red;
            BarraCarregamento("Carregando");
            Console.ResetColor();

            Console.Clear();

            string opcao;

            do
            {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(@$"
=======================================
│   Selecione uma das opções abaixo:  │
│                                     │
│         1 - Pessoa Física           │
│         2 - Pessoa Jurídica         │
│                                     │
│         3 - Sair do Menu            │ 
│                                     │
=======================================
            ");
            Console.ResetColor();

            opcao = Console.ReadLine();

            switch(opcao)
            {
                case "1":
                    Console.Clear();

                    PessoaFisica pfMetodos = new PessoaFisica();
                    PessoaFisica novaPf = new PessoaFisica();
                    Endereco novoEndePf = new Endereco();

                    novaPf.nome = "Jeff";
                    novaPf.cpf = "347854738";
                    novaPf.dataNascimento = new DateTime(2000,4,3);
                    novaPf.rendimento = 2478.4f;

                    novaPf.endereco = novoEndePf;
                    novaPf.endereco.logradouro = "Abacaxi Verde da Costa";
                    novaPf.endereco.numero = 548;
                    novaPf.endereco.complemento = "Casa";
                    novaPf.endereco.enderecoComercial = false;

                    Console.WriteLine(@$"
Nome: {novaPf.nome}
CPF: {novaPf.cpf}
Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
Complemento: {novaPf.endereco.complemento}
Validação data de nascimento: {(pfMetodos.ValidarNascimento(novaPf.dataNascimento) ? "Maior de 18 anos" : "Menor de 18 anos")}
Taxa de Imposto: {pfMetodos.PagarImposto(novaPf.rendimento).ToString("C")}
                    ");

                    Thread.Sleep(3000);
                    Console.Clear();
                   break;

                case "2":
                    Console.Clear();

                    PessoaJuridica pjMetodos = new PessoaJuridica();
                    PessoaJuridica novaPj = new PessoaJuridica();
                    Endereco novoEndePj = new Endereco();
                    
                    novaPj.nome = "Martin";
                    novaPj.cnpj = "53579245000101";
                    novaPj.razaoSocial = "Razão Social PJ";
                    novaPj.rendimento = 15637.8f;

                    novaPj.endereco = novoEndePj;
                    novaPj.endereco.logradouro = "Peixe Espada Azul";
                    novaPj.endereco.numero = 250;
                    novaPj.endereco.complemento = "Empresa Logística";
                    novaPj.endereco.enderecoComercial = true;

                    Console.WriteLine(@$"
Nome: {novaPj.nome}
CNPJ: {novaPj.cnpj}
Razão Social: {novaPj.razaoSocial}
Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero}
Validação CNPJ: {(pjMetodos.ValidarCnpj(novaPj.cnpj) ? "Válido" : "Inválido")}
Taxa de Imposto: {pjMetodos.PagarImposto(novaPj.rendimento).ToString("C")}
                    ");

                    Thread.Sleep(3000);
                    Console.Clear();
                   break;

                case "3":
                    BarraCarregamento("Saindo do sistema");
                   break;

                default:
                    Console.WriteLine("Opção inválida. Por favor tente novamente.");

                    Thread.Sleep(2500);
                    Console.Clear();
                   break;
            }
            
            }while(opcao != "3");
        }

        static void BarraCarregamento(string textoCarregar)
        {
            Console.Write(textoCarregar);
            
            for(int contador = 0; contador < 10; contador++)
            {
                Thread.Sleep(450);
                Console.Write(" . ");
            }
        }
    }
}
