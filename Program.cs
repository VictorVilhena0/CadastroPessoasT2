using System;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaFisica pfMetodos = new PessoaFisica();
            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEnde = new Endereco();

            novaPf.nome = "Jeff";
            novaPf.cpf = "347854738";
            novaPf.dataNascimento = new DateTime(2009,4,3);
            novaPf.rendimento = 4587.1f;

            novaPf.endereco = novoEnde;
            novaPf.endereco.logradouro = "Abacaxi Verde da Costa";
            novaPf.endereco.numero = 548;
            novaPf.endereco.complemento = "Casa";
            novaPf.endereco.enderecoComercial = false;
            
            Console.WriteLine(@$"
Nome: {novaPf.nome}
CPF: {novaPf.cpf}
Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
Complemento: {novaPf.endereco.complemento}
            ");
            Console.WriteLine($"{pfMetodos.ValidarNascimento(novaPf.dataNascimento)}");
        }
    }
}
