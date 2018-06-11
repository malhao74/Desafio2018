using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Artigo(int idNew, string nomeNew, string descricaoNew)
        {
            Id = idNew;
            Nome = nomeNew;
            Descricao = descricaoNew;
        }
    }

}