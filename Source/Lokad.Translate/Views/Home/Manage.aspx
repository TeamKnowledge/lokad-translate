<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Manage - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Manage</h2>

	<ul>
		<li class="hbig"><%= Html.ActionLink("Jobs", "Index", "UpdateBatches")%></li>
		<li class="hbig"><%= Html.ActionLink("Feeds", "Index", "Feeds")%></li>
        <li class="hbig"><%= Html.ActionLink("Languages", "Index", "Langs")%></li>
        <li class="hbig"><%= Html.ActionLink("Users", "Index", "Users")%></li>
        <li class="hbig"><%= Html.ActionLink("Regex", "Index", "RestRegex")%></li>
        <li class="hbig"><%= Html.ActionLink("Cron", "Cron", "Home")%></li>
        <li class="hbig"><%= Html.ActionLink("Errors", "Index", "elmah.axd")%></li>
	</ul>
</asp:Content>
