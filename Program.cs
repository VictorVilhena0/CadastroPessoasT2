using System;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaJuridica novaPj = new PessoaJuridica();
            novaPj.nome = "Jen";
            novaPj.endereco = "Rua Spetsnaz";
            novaPj.razaoSocial = "Companhia de Conserto de Aparelhos Eletrônicos";
            
            Console.WriteLine($"Nome: {novaPj.nome}\nEndereço: {novaPj.endereco}\nRazão Social: {novaPj.razaoSocial}\n");

            PessoaFisica novaPf = new PessoaFisica();
            novaPf.nome = "Jeff";
            novaPf.cpf = "5637.3526.25"; //este número é só para exemplo

            Console.WriteLine($"Nome: {novaPf.nome}\nCPF: {novaPf.cpf}");
        }
    }
}
