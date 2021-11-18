namespace CadastroPessoas
{
    public abstract class Pessoa
    {
         public string nome {get; set;}
         public string endereco {get; set;}
         public float rendimento {get; set;}
         public abstract float PagarImposto(float rendimento);
    }
}