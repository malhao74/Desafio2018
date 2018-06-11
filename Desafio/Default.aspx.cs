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
                        TreeViewArtigos.Nodes.Add(treeNode);
                    }
                    PageConfig(listaArtigos.Count);
                }
                catch (Exception)
                {
                    // Colocar informação de site em construção?
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
                treeNode.Collapse();
            }
            else
            {
                string valuePath = treeNode.ValuePath;
                int[] intPath = valuePath.Split('/').Select<string, int>(x => Convert.ToInt32(x)).ToArray();

                List<Artigo> listaArtigos = await DataLayerWebApi.GetArtigosAt(intPath);

                // Se o artigo de facto for um a categoria.
                if (listaArtigos.Count > 1 || listaArtigos[0].Descricao == null)
                {
                    foreach (Artigo artigo in listaArtigos)
                    {
                        TreeNode treeNodeNew = new TreeNode(artigo.Nome, artigo.Id.ToString());
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
        // Configuração inicial da página.
        private void PageConfig(int numeroNos)
        {
            TextBoxArtigosDescricao.TextMode = TextBoxMode.MultiLine;
            TextBoxArtigosDescricao.BorderStyle = BorderStyle.None;
            TextBoxArtigosDescricao.ReadOnly = true;
            TextBoxArtigosDescricao.Height = TreeViewArtigos.Height;
            TextBoxArtigosDescricao.Rows = numeroNos;
        }
        #endregion
    }
}