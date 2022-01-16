using System.IO;

namespace CadastroPessoas
{
    public abstract class Pessoa
    {
         public string nome {get; set;}
         public Endereco endereco {get; set;}
         public float rendimento {get; set;}
         public abstract float PagarImposto(float rendimento);
         public void VerificarPastaArquivo(string caminho)
         {
            string pasta = caminho.Split("/")[0];
            
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if(!File.Exists(caminho))
            {
                FileStream file = File.Create(caminho);
                file.Close();
            }
         }
    }
}