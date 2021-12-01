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
            throw new NotImplementedException();
        }
    }
}