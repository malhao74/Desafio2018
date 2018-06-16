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
        #region Definicao de variaveis
        private readonly string iconCategoria = "Generic_icon-icons.com_75002_32.ico";
        private readonly string iconArtigo = "icon-document_87920_32.ico";
        #endregion
        #region Eventos
        async void Page_loadComplete(object sender, EventArgs e)
        {
            if(IsPostBack == false || TreeViewArtigos.Nodes.Count == 0)
            {
                try
                {
                    // Carregamento inicial de artigos.
                    List<Artigo> listaArtigos = await DataLayerWebApi.GetArtigosAtRoot();
                    foreach (Artigo artigo in listaArtigos)
                    {
                        TreeNode treeNode = new TreeNode(artigo.Nome, artigo.Id.ToString());
                        // Se não tem descricao é uma categoria
                        treeNode.ImageUrl = GetIcon(artigo.Descricao == null); ;
                        TreeViewArtigos.Nodes.Add(treeNode);
                    }
                    TextBoxArtigosDescricaoConfig(listaArtigos.Count);
                }
                catch (Exception ex)
                {
                    // Colocar informação de site em construção?
                    Console.WriteLine($"Problemas no carregamento inicial da tree: {ex.Message}");
                }
            }
        }
        protected async void TreeViewArtigos_SelectedNodeChanged(object sender, EventArgs e)
        {
            TextBoxArtigosDescricao.Text = "";

            TreeNode treeNode = TreeViewArtigos.SelectedNode;
            // Se já tiver sido alimentado anteriormente.
            if (treeNode.ChildNodes.Count != 0)
            {
                treeNode.Expand();
            }
            else
            {
                string valuePath = treeNode.ValuePath;
                int[] intPath = valuePath.Split('/').Select<string, int>(x => Convert.ToInt32(x)).ToArray();

                List<Artigo> listaArtigos = await DataLayerWebApi.GetArtigosAt(intPath);

                // Se o artigo de facto for um a categoria.
                if (listaArtigos.Count > 1 || listaArtigos[0].Descricao == null)
                {
                    treeNode.SelectAction = TreeNodeSelectAction.Expand;
                    foreach (Artigo artigo in listaArtigos)
                    {
                        TreeNode treeNodeNew = new TreeNode(artigo.Nome, artigo.Id.ToString());
                        // Se não tem descricao é uma categoria
                        treeNodeNew.ImageUrl = GetIcon(artigo.Descricao == null);

                        treeNode.ChildNodes.Add(treeNodeNew);
                    }
                }
                else
                {
                    TextBoxArtigosDescricao.Text = listaArtigos[0].Descricao;
                }
            }
        }
        #endregion

        #region Metodos privados
        // Configuração da TextBoxArtigosDescricao.
        private void TextBoxArtigosDescricaoConfig(int numeroNos)
        {
            TextBoxArtigosDescricao.TextMode = TextBoxMode.MultiLine;
            TextBoxArtigosDescricao.BorderStyle = BorderStyle.None;
            TextBoxArtigosDescricao.ReadOnly = true;
            TextBoxArtigosDescricao.Height = TreeViewArtigos.Height;
            TextBoxArtigosDescricao.Rows = numeroNos;
        }
        // Contiguracao do icon dos nos
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
        #endregion
    }
}