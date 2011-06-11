<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Manage</h2>
    <p>Administrate your Lokad.Translate instance.</p>
    <ul>
        <li class="hbig"><%= Html.ActionLink("Jobs", "Index", "UpdateBatches")%></li>
        <li class="hbig"><%= Html.ActionLink("Feeds", "Index", "Feeds")%></li>
        <li class="hbig"><%= Html.ActionLink("Languages", "Index", "Langs")%></li>
        <li class="hbig"><%= Html.ActionLink("Users", "Index", "Users")%></li>
        <li class="hbig"><%= Html.ActionLink("Regex", "Index", "RestRegex")%></li>
        <%-- [vermorel] This one is only likely to wreak havoc.
         <li class="hbig"><%= Html.ActionLink("Cron", "Cron", "Home")%></li>--%>
    </ul>
</asp:Content>
