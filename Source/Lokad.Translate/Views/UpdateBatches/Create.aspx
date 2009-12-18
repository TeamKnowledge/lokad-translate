<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.UpdateBatch>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Job
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Job</h2>

    <table>
        <tr>
            <th>
                Translator
            </th>
            <th>
                WordCount
            </th>
            <td>
            </td>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.User.DisplayName) %>
            </td>
            <td>
                <%= Html.Encode(item.WordCount) %>
            </td>
            <td>
				<%= Html.ActionLink("Create", "ConfirmCreate", new { id = item.User.Id })%>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

