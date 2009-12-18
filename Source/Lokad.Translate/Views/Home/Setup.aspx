<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Setup Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Setup Lokad.Translate</h2>

	<p><%= ViewData["SetupMessage"] %></p>
	
	<p>This page is used to insert the initial administrator in the account. Once a user has been
	inserted into the account, the setup is disabled.</p>
	
	<p><%= Html.ActionLink("Confirm Setup", "ConfirmSetup")%></p>
</asp:Content>
