using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Desafio
{
    public class DataLayerWebApi
    {
        #region Declaracao de variaveis
        private static readonly string rootPath = "http://localhost:54064/api/Default";
        #endregion

        #region Metodos publicos

        public static async Task<List<Artigo>> GetArtigosAtRoot()
        {
            return await GetArtigos(rootPath);
        }

        public static async Task<List<Artigo>> GetArtigosAt(int[] ids)
        {
            string path = rootPath + "?";
            string separador = "";

            for (int i = 0; i < ids.Length; i++)
            {
                path += $"{separador}id={ids[i]}";

                separador = "&";
            }

            return await GetArtigos(path);
        }

        #endregion

        #region Metodos privados

        private static async Task<List<Artigo>> GetArtigos(string path)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string resposta = await response.Content.ReadAsStringAsync();
                resposta = resposta.Replace("\\", string.Empty);
                resposta = resposta.Trim('"');
                //resposta = "[{\"Id\":1,\"Nome\":\"Isto já foi um artigo\",\"Descricao\":null},{\"Id\":2,\"Nome\":\"Artigo 2\",\"Descricao\":\"Texto referente ao artigo 2....\"},{\"Id\":3,\"Nome\":\"Isto não é um artigo...\",\"Descricao\":null},{\"Id\":4,\"Nome\":\"Artigo 4\",\"Descricao\":\"Texto referente ao artigo 4....\"}]";
                //resposta = resposta.Replace(@"\\\",@"\");

                List<Artigo> listaArtigos = JsonConvert.DeserializeObject<List<Artigo>>(resposta);
                return listaArtigos;
            }

            return null;

        }
        #endregion
    }
}