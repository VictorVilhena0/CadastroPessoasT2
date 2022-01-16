using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@$"
=======================================
│        Menu de cadastro para        │
│     pessoas Físicas e Jurídicas     │
=======================================
            ");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Black;
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
                    string opcaoPf;
                    PessoaFisica pfMetodos = new PessoaFisica();

                    do
                    {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($@"
=======================================
│   Selecione uma das opções abaixo:  │
│                                     │
│     1 - Cadastrar Pessoa Física     │
│      2 - Listar Pessoa Física       │
│                                     │
│     3 - Voltar ao menu anterior     │
│                                     │
=======================================                    
                    ");
                    Console.ResetColor();

                    opcaoPf = Console.ReadLine();

                    switch(opcaoPf)
                    {
                        case "1":
                            PessoaFisica novaPf = new PessoaFisica();
                            Endereco novoEndePf = new Endereco();

                            Console.Clear();
                            
                            Console.WriteLine("Digite o seu nome:");
                            novaPf.nome = Console.ReadLine();
                            Console.Clear();

                            do
                            {
                            Console.Clear();
                            Console.WriteLine("Digite o seu CPF:");
                            novaPf.cpf = Console.ReadLine();
                            if(novaPf.cpf.Length < 11 || novaPf.cpf.Length > 11)
                            {
                                Console.WriteLine("CPF inválido. Por favor tente novamente.");
                                Thread.Sleep(3000);
                            }
                            }while(novaPf.cpf.Length != 11);

                            Console.Clear();

                            bool dataValida;
                            do
                            {
                            Console.WriteLine("Digite a sua data de nascimento (AAAA-MM-DD):");
                            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                            dataValida = pfMetodos.ValidarNascimento(dataNascimento);

                            if(dataValida)
                            {
                                novaPf.dataNascimento = dataNascimento;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Data inserida não é válida, por favor tente novamente.");
                                Thread.Sleep(2500);
                                Console.ResetColor();
                                Console.Clear();
                            }                            
                            }
                            while(dataValida == false);

                            Console.Clear();

                            Console.WriteLine("Digite o seu rendimento:");
                            novaPf.rendimento = int.Parse(Console.ReadLine());
                            Console.Clear();

                            novaPf.endereco = novoEndePf;
                            Console.WriteLine("Digite o seu endereço:");
                            novaPf.endereco.logradouro = Console.ReadLine();
                            Console.Clear();
                            
                            Console.WriteLine("Digite o número da estrutura:");
                            novaPf.endereco.numero = int.Parse(Console.ReadLine());
                            Console.Clear();

                            Console.WriteLine("Digite o seu complemento:");
                            novaPf.endereco.complemento = Console.ReadLine();
                            Console.Clear();
                            
                            Console.WriteLine("Se o seu endereço é comercial, digite" + " S, " + "caso contrário, " + "N");
                            string opcaoComercial = Console.ReadLine().ToUpper();

                            if(opcaoComercial == "S")
                            {
                                novoEndePf.enderecoComercial = true;
                            }
                            else
                            {
                                novoEndePf.enderecoComercial = false;
                            }

                            listaPf.Add(novaPf);

                            using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))//Vai criar um arquivo "txt" na raíz do projeto (Pessoa Física)
                            {
                                sw.Write($"Nome: {novaPf.nome}");
                            }

                            pfMetodos.VerificarPastaArquivo(pfMetodos.caminhoPf);
                            pfMetodos.InserirPf(novaPf);
                        break;
            
                        case "2":
                            Console.Clear();
                            
                            List<PessoaFisica> listaPF = pfMetodos.Ler();

                            if(listaPF.Count > 0)
                            {
                                foreach(PessoaFisica cadaPf in listaPF)
                                {
                                    Console.WriteLine(@$"
Nome: {cadaPf.nome}
CPF: {cadaPf.cpf}
");
                                    Thread.Sleep(3500);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Lista vazia.");
                                Thread.Sleep(3500);
                            }
                        break;

                        case "3":
                            BarraCarregamento("Voltando ao menu anterior");
                            Console.Clear();
                        break;

                        default:
                            Console.WriteLine("Valor inserido não identificado, por favor tente novamente.");
                            Thread.Sleep(600);
                            Console.Clear();
                        break;
                    }                  
                    }
                    while(opcaoPf != "3");
                    
                break; //esse "break" serve para quebrar o case "1" do switch(opcao)

                case "2":
                    string opcaoPj;
                    PessoaJuridica pjMetodos = new PessoaJuridica();

                    do
                    {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@$"
=======================================
│   Selecione uma das opções abaixo:  │
│                                     │
│    1 - Cadastrar Pessoa Jurídica    │
│     2 - Listar Pessoa Jurídica      │
│                                     │
│     3 - Voltar ao menu anterior     │
│                                     │
=======================================                    
                    ");
                    Console.ResetColor();

                    opcaoPj = Console.ReadLine();

                    switch(opcaoPj)
                    {
                        case "1":
                    
                            PessoaJuridica novaPj = new PessoaJuridica();
                            Endereco novoEndePj = new Endereco();
                            
                            Console.Clear();

                            Console.WriteLine("Digite o seu nome:");
                            novaPj.nome = Console.ReadLine();
                            Console.Clear();

                            string cnpj;
                            
                            bool cnpjValido;
                            do
                            {
                                Console.WriteLine("Digite o seu CNPJ:");
                                cnpj = Console.ReadLine();
                                
                                cnpjValido = pjMetodos.ValidarCnpj(cnpj);

                                if(cnpjValido)
                                {
                                    novaPj.cnpj = cnpj;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("CNPJ inválido, por favor tente novamente");
                                    Thread.Sleep(3000);
                                    Console.ResetColor();
                                    Console.Clear();
                                }                           
                            }
                            while(cnpjValido == false);                           
                            
                            Console.Clear();

                            Console.WriteLine("Digite a sua razão social:");
                            novaPj.razaoSocial = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Digite o seu rendimento:");
                            novaPj.rendimento = int.Parse(Console.ReadLine());
                            Console.Clear();

                            novaPj.endereco = novoEndePj;
                            Console.WriteLine("Digite o seu endereço:");
                            novaPj.endereco.logradouro = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Digite o número da estrutura:");
                            novaPj.endereco.numero = int.Parse(Console.ReadLine());
                            Console.Clear();

                            Console.WriteLine("Digite o seu complemento:");
                            novaPj.endereco.complemento = Console.ReadLine();
                            Console.Clear();

                            novaPj.endereco.enderecoComercial = true;

                            listaPj.Add(novaPj);

                            using (StreamWriter sw = new StreamWriter($"{novaPj.nome}.txt"))//Vai criar um arquivo "txt" na raíz do projeto (Pessoa Jurídica)
                            {
                                sw.Write($"Nome: {novaPj.nome}");
                            }

                            pjMetodos.VerificarPastaArquivo(pjMetodos.caminhoPj);
                            pjMetodos.InserirPj(novaPj);
                        break;

                        case "2":
                            Console.Clear();

                            List<PessoaJuridica> listaPJ = pjMetodos.Ler();

                            if(listaPJ.Count > 0)
                            {
                                foreach(PessoaJuridica cadaPj in listaPJ)
                                {
                                    Console.WriteLine(@$"
Nome: {cadaPj.nome}
CNPJ: {cadaPj.cnpj}
Razão social: {cadaPj.razaoSocial}
");
                                    Thread.Sleep(3500);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Lista vazia.");
                                Thread.Sleep(3500);
                            }
                        break;

                        case "3":
                            BarraCarregamento("Voltando ao menu anterior");
                            Console.Clear();
                        break;
                            
                        default:
                            Console.WriteLine("Valor inserido não identificado, por favor tente novamente.");
                            Thread.Sleep(3000);
                            Console.Clear();
                        break;

                    }                    
                    }
                    while(opcaoPj != "3");
                
                break; //esse "break" serve para quebrar o case "2" do switch(opcao)

                case "3":
                    BarraCarregamento("Saindo do sistema");
                break;

                default:
                    Console.WriteLine("Opção inválida. Por favor tente novamente.");

                    Thread.Sleep(2500);
                    Console.Clear();
                break;
            }                        
            }
            while(opcao != "3");
        }

        static void BarraCarregamento(string textoCarregar)
        {
            Console.Write(textoCarregar);
            
            for(int contador = 0; contador < 10; contador++)
            {
                Thread.Sleep(300);
                Console.Write(" . ");
            }
        }
    }
}
