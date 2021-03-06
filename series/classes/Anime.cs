using System;

namespace series.classes
{
    public class Anime : EntidadeBase
    {
            // ATRIBUTOS --------------

        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        public bool Excluido {get; set;}

            // MÉTODOS ---------------- 

        public Anime (int id, Genero genero, string titulo, string descricao, int ano )   
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Estreia: " + this.Ano + Environment.NewLine;

            if(this.Excluido == true)
            {
                return retorno = "Anime Excluido"; 
            }

            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}