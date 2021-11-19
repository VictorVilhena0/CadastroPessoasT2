namespace CadastroPessoas
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj {get; set;}
        public string razaoSocial {get; set;}
        public bool ValidarCnpj(string cnpj)
        {
            return true;
        }
        public override float PagarImposto(float rendimento)
        {
            throw new System.NotImplementedException();
        }
    }
}