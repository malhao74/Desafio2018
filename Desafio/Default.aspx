<%@ Page Title="Home Page" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Desafio._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Desafio</h1>
        <p class="lead">Criar uma aplicação que consome uma API REST.</p>
        <p><a href="https://pt.wikipedia.org/wiki/REST" class="btn btn-primary btn-lg">Saiba mais &raquo;</a></p>
    </div>
     <div class="row">
        <div class="col-sm-4">
            <asp:TreeView ID="TreeViewArticles" OnSelectedNodeChanged ="TreeViewArticles_SelectedNodeChanged" runat="server" ImageSet="Faq">
                <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="DarkBlue" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                <ParentNodeStyle Font-Bold="False" />
                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"/>
            </asp:TreeView>
        </div>
        <div class="col-sm-8">
            <asp:Label ID="LabelDescricao" runat="server" />
         </div>
    </div>
</asp:Content>
