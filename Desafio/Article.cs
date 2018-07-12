using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio
{
    /// <summary>
    /// Class that encapsulates the article information
    /// </summary>
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Article(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}