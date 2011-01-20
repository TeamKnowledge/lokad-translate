<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.ViewModels.PageMappingsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mappings - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Mappings of <%= String.Format("<a href=\"{0}\">{0}</a>", Model.PageUrl) %></h2>

	<p><%= Html.ActionLink("Back", "Index") %></p>
	
    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Created
            </th>
            <th>
                Code
            </th>
            <th>
                Target
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model.Mappings) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", "Maps", new { id = item.Id }, null) %>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Created)) %>
            </td>
            <td>
                <%= Html.Encode(item.Code) %>
            </td>
            <td>
				 <%= String.Format("<a href=\"{0}\">{0}</a>", item.DestinationUrl) %>
            </td>
            <td>
				<%= Html.ActionLink("Delete", "DeleteMapping", new { id = item.Id }) %>
            </td>
        </tr>
    
    <% } %>

    </table>
    
    <p>
        <%= Html.ActionLink("Create Mappings", "CreateMappings", new
			{
				id = Model.Id
			})%>
    </p>

</asp:Content>

