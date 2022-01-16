using System;
using System.IO;
using System.Collections.Generic;

namespace CadastroPessoas
{
    public class PessoaFisica : Pessoa
    {
        public string cpf {get; set;}
        public DateTime dataNascimento {get; set;}
        public string caminhoPf {get; private set;} = "Database/PessoaFisica.csv";
        public bool ValidarNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays / 365;
                
            if(anos >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public string PrepararLinhaCsvPf(PessoaFisica pf)
        {
            string linha = $"{pf.nome};{pf.cpf};";
            return linha;
        }
        public void InserirPf(PessoaFisica pf)
        {
            string[] linhas = {PrepararLinhaCsvPf(pf)};

            File.AppendAllLines(caminhoPf, linhas);
        }
        public List<PessoaFisica> Ler()
        {
            List<PessoaFisica> listaPF = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminhoPf);

            foreach(string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                PessoaFisica cadaPf = new PessoaFisica();

                cadaPf.nome = atributos[0];
                cadaPf.cpf = atributos[1];

                listaPF.Add(cadaPf);
            }

            return listaPF;
        }
    }
}