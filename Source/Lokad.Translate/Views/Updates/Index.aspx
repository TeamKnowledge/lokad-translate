<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Update>>" %>
<%@ Import Namespace="Lokad.Translate"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Worklogs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Worklogs</h2>

    <table>
        <tr>
			<th>
                Id
            </th>
            <th>
                Created
            </th>
            <th>
                Target
            </th>
            <th>
                Word Count
            </th>
            <th>
                Version
            </th>
            <th>
                Translator
            </th>
            <td></td>
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
                <%= Html.CompactLink(item.Mapping.DestinationUrl) %>
            </td>
            <td>
                <%= Html.Encode(item.WordCount) %>
            </td>
            <td>
                <%= Html.Encode(item.Version) %>
            </td>
            <td>
                <%= Html.Encode(item.User.DisplayName) %>
            </td>
            <td>
				<% if (item.UpdateBatch == null) { %>
                <%= Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
                <% } %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

