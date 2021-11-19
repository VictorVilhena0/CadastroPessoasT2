using System;

namespace CadastroPessoas
{
    public class PessoaFisica : Pessoa
    {
        public string cpf {get; set;}
        public DateTime dataNascimento {get; set;}
        public bool ValidarNascimento(DateTime dataNasc)
        {
            return true;
        }
        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }
    }
}