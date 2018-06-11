<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Desafio.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Luis Malhão</h3>

<%--    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>--%>

    <address>
        <strong>Email:</strong>   <a href="mailto:luis.malhao@gmail.com">luis.malhao@gmail.com</a><br />
    </address>
</asp:Content>
