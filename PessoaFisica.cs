using System;

namespace CadastroPessoas
{
    public class PessoaFisica : Pessoa
    {
        public string cpf {get; set;}
        public DateTime dataNascimento {get; set;}
        public bool ValidarNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays / 365;

            Console.WriteLine($"\nIdade: {anos}");

            if(anos >= 18)
            {
                return true;
            }
            
            return false;
        }
        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }
    }
}