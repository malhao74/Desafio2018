<%@ Page Title="Home Page" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Desafio._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Desafio</h1>
        <p class="lead">Criar uma aplicação que consome uma API REST.</p>
        <p><a href="https://pt.wikipedia.org/wiki/REST" class="btn btn-primary btn-lg">Saiba mais &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:TreeView ID="TreeViewArtigos" OnSelectedNodeChanged ="TreeViewArtigos_SelectedNodeChanged" runat="server" ImageSet="Faq">
                <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="DarkBlue" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                <ParentNodeStyle Font-Bold="False" />
                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
            </asp:TreeView>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="TextBoxArtigosDescricao"  Width = "200" style ="resize:none" runat="server"></asp:TextBox>
        </div>
    </div>

</asp:Content>
