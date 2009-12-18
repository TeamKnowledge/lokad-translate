<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cron Job Results
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cron Job Results</h2>
    <ul>
		<li><%= ViewData["PagesRefreshed"] %> pages refreshed.</li>
		<li><%= ViewData["MappingsInserted"] %> mappings inserted.</li>
    </ul>

</asp:Content>
