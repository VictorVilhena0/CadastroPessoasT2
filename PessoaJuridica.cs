using System;

namespace CadastroPessoas
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj {get; set;}
        public string razaoSocial {get; set;}
        public bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length == 14 && cnpj.Substring(8, 4) == "0001")
            {
                return true;
            }

            return false;
        }
        public override float PagarImposto(float rendimento)
        {
            if(rendimento <= 3000)
            {
                float taxa = (rendimento/100) * 3;
                return taxa;
            }
            else if(rendimento > 3000 && rendimento <= 6000)
            {
                float taxa = (rendimento/100) * 5;
                return taxa;
            }
            else if(rendimento > 6000 && rendimento <= 10000)
            {
                float taxa = (rendimento/100) * 7;
                return taxa;
            }
            else
            {
                float taxa = (rendimento/100) * 9;
                return taxa;
            }
        }
    }
}