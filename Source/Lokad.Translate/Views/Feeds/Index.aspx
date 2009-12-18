<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Feed>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Feeds
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Feeds</h2>
	<p><%= Html.Encode(ViewData["Message"]) %> </p>
    <table>
        <tr>
            <th></th>
            <th>
                Created
            </th>
            <th>
                Name
            </th>
            <th>
                Url
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.Id }) %> |
                <%= Html.ActionLink("Refresh", "Refresh", new { id = item.Id }) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Created)) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= String.Format("<a href=\"{0}\">{0}</a>", item.Url) %>
            </td>
            <td>
                <%= Html.ActionLink("Delete", "Delete", new { id = item.Id }) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Add New", "Create") %>
    </p>

</asp:Content>

