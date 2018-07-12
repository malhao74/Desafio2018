using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace Desafio
{
    public partial class _Default : Page
    {
        #region Field definition
        private readonly string iconCategoria = "~/Images/Generic_icon-icons.com_75002_32.ico";
        private readonly string iconArtigo = "~/Images/icon-document_87920_32.ico";
        #endregion

        #region Events
        async void Page_LoadComplete(object sender, EventArgs e)
        {
            if(IsPostBack == false || TreeViewArticles.Nodes.Count == 0)
            {
                try
                {
                    // Initial article update
                    List<Article> listaArtigos = await DataLayerWebAPI.GetArticlesAtRootAsync();
                    foreach (Article artigo in listaArtigos)
                    {
                        TreeNode treeNode = new TreeNode(artigo.Name, artigo.Id.ToString())
                        {
                            // If the article has no description then it's category
                            ImageUrl = GetIcon(artigo.Description == null)
                        };
                        
                        TreeViewArticles.Nodes.Add(treeNode);
                    }
                }
                catch (Exception ex)
                {
                    // Put up a site in construction page?
                    Console.WriteLine($"Problemas no carregamento inicial da tree: {ex.Message}");
                }
            }
        }
        protected async void TreeViewArticles_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode treeNode = TreeViewArticles.SelectedNode;
            // If the node as content already, it expands the node 
            if (treeNode.ChildNodes.Count != 0)
            {
                treeNode.Expand();
            }
            else
            {
                string valuePath = treeNode.ValuePath;
                int[] intPath = valuePath.Split('/').Select<string, int>(x => Convert.ToInt32(x)).ToArray();

                List<Article> listaArtigos = await DataLayerWebAPI.GetArticlesAtAsync(intPath);

                // If the article is in fact a category
                if (listaArtigos.Count > 1 || listaArtigos[0].Description == null)
                {
                    treeNode.SelectAction = TreeNodeSelectAction.Expand;
                    foreach (Article artigo in listaArtigos)
                    {
                        TreeNode treeNodeNew = new TreeNode(artigo.Name, artigo.Id.ToString())
                        {
                            // If the article has no description the it's a category
                            ImageUrl = GetIcon(artigo.Description == null)
                        };

                        treeNode.ChildNodes.Add(treeNodeNew);
                    }
                }
                else
                {
                    LabelDescricao.Text = listaArtigos[0].Description;
                }
            }
        }
        #endregion

        /// <summary>
        /// Node icon configuration
        /// </summary>
        /// <param name="isCategoria"></param>
        /// <returns></returns>
        private string GetIcon(bool isCategoria)
        {
            if (isCategoria)
            {
                return iconCategoria;
            }
            else
            {
                return iconArtigo;
            }
        }
    }
}