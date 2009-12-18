<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.UpdateBatch>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Jobs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Jobs</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Created
            </th>
            <th>
                Translator
            </th>
            <th>
                WordCount
            </th>
            <th>
				IsPaid
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Created)) %>
            </td>
            <td>
                <%= Html.Encode(item.User.DisplayName) %>
            </td>
            <td>
                <%= Html.Encode(item.WordCount) %>
            </td>
			<td>
                <%= Html.Encode(item.IsPaid ? "Yes" : "No") %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>
