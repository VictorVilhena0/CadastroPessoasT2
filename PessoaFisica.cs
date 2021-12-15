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
                
            if(anos >= 18)
            {
                return true;
            }
            
            return false;
        }
        public override float PagarImposto(float rendimento)
        {
            if(rendimento <= 1500)
            {
                return 0;
            }
            else if(rendimento > 1500 && rendimento <= 3500)
            {
                float taxa = (rendimento/100) * 2;
                return taxa;
            }
            else if(rendimento > 3500 && rendimento <= 6000)
            {
                float taxa = (rendimento/100) * 3.5f;
                return taxa;
            }
            else
            {
                float taxa = (rendimento/100) * 5;
                return taxa;
            }
        }
    }
}