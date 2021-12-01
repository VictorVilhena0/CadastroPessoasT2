using System;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaFisica pfMetodos = new PessoaFisica();
            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEndePf = new Endereco();

            novaPf.nome = "Jeff";
            novaPf.cpf = "347854738";
            novaPf.dataNascimento = new DateTime(2009,4,3);
            novaPf.rendimento = 4587.1f;

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
Validação data de nascimento: {pfMetodos.ValidarNascimento(novaPf.dataNascimento)}
            ");

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
Validação CNPJ: {pjMetodos.ValidarCnpj(novaPj.cnpj)}
            ");
        }
    }
}
