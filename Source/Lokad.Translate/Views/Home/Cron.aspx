<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cron Job Results
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cron Job Results</h2>
    <p>When this page gets displayed, Lokad.Translate refreshes all web feeds, pulling
    out new page updates. By default, you don't need to do this manually, as Lokad.Translate
    auto-refresh the web feeds every few minutes.</p>
    <ul>
		<li><%= ViewData["PagesRefreshed"] %> pages refreshed.</li>
		<li><%= ViewData["MappingsInserted"] %> mappings inserted.</li>
    </ul>

</asp:Content>
