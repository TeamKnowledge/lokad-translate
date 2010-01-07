<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Mapping>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete Page - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Page <%= String.Format("<a href=\"{0}\">{0}</a>", ViewData["PageUrl"]) %></p></h2>

	<%= Html.Encode(ViewData["Message"]) %></p>

	<p>List of mappings that will be deleted.</p>
    <table>
        <tr>
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
                DestinationUrl
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
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
        <%= Html.ActionLink("Confirm delete", "ConfirmDelete", new
			{
				id = ViewContext.Controller.ValueProvider["id"].RawValue
			})%>
    </p>

</asp:Content>

