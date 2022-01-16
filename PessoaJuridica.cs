using System;
using System.IO;
using System.Collections.Generic;

namespace CadastroPessoas
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj {get; set;}
        public string razaoSocial {get; set;}
        public string caminhoPj {get; private set;} = "Database/PessoaJuridica.csv";
        public bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length == 14 && cnpj.Substring(8, 4) == "0001")
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
        public string PrepararLinhaCsvPj(PessoaJuridica pj)
        {
            string linha = $"{pj.nome};{pj.cnpj};{pj.razaoSocial}";
            return linha;
        }
        public void InserirPj(PessoaJuridica pj)
        {
            string[] linhas = {PrepararLinhaCsvPj(pj)};

            File.AppendAllLines(caminhoPj, linhas);
        }
        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminhoPj);

            foreach(string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];

                listaPJ.Add(cadaPj);
            }

            return listaPJ;
        }
    }
}