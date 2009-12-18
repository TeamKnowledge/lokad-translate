<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Mapping>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mappings
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Mappings of <%= String.Format("<a href=\"{0}\">{0}</a>", ViewData["PageUrl"]) %></h2>

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
        </tr>

    <% foreach (var item in Model) { %>
    
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
        </tr>
    
    <% } %>

    </table>
    
    <p>
        <%= Html.ActionLink("Create Mappings", "CreateMappings", new
			{
				id = ViewContext.Controller.ValueProvider["id"].RawValue
			})%>
    </p>

</asp:Content>

