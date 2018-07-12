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
    /// <summary>
    /// Data layer used to access the web API
    /// </summary>
    public static class DataLayerWebAPI
    {
        private const string rootPath = "http://localhost:54064/api/Default";

        #region Public methods

        public static async Task<List<Article>> GetArticlesAtRootAsync() => await GetArticlesAtAsync(rootPath);

        public static async Task<List<Article>> GetArticlesAtAsync(int[] ids)
        {
            string path = rootPath;
            string separador = "?";

            for (int i = 0; i < ids.Length; i++)
            {
                path += $"{separador}id={ids[i]}";

                separador = "&";
            }
            return await GetArticlesAtAsync(path);
        }

        #endregion

        #region Private methods

        private static async Task<List<Article>> GetArticlesAtAsync(string path)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            client.Dispose();

            if (response.IsSuccessStatusCode)
            {
                string resposta = await response.Content.ReadAsStringAsync();
                resposta = resposta.Replace("\\", string.Empty);
                resposta = resposta.Trim('"');

                List<Article> listaArtigos = JsonConvert.DeserializeObject<List<Article>>(resposta);
                return listaArtigos;
            }
            return null;
        }
        #endregion
    }
}