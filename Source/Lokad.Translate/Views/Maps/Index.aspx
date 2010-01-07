<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Lang>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Select your target language - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Select your target language</h2>

	<ul>
    <% foreach (var item in Model) { %>
    
        <li class="hbig">
                <%= Html.ActionLink(item.Code, "List", new { id = item.Code })%>
        </li>
    
    <% } %>
    </ul>

</asp:Content>

