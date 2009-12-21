<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.RestRegex>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Regex
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Regex</h2>
    
    <p>Lokad.Translate lets you customize how your translators will
    interact the 3rd party web app being translated.</p>
    
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

    <table>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                History
            </th>
            <th>
                Diff
            </th>
            <th>
                Edit
            </th>

            <th>
                Match Regex
            </th>
            <th>
                Replace Regex
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.IsEdit) %>
            </td>
            <td>
                <%= Html.Encode(item.IsHistory) %>
            </td>
            <td>
                <%= Html.Encode(item.IsDiff) %>
            </td>
            <td>
                <%= Html.Encode(item.MatchRegex) %>
            </td>
            <td>
                <%= Html.Encode(item.ReplaceRegex) %>
            </td>
            <td>
				<%= Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
            </td>
        </tr>
    
    <% } %>

    </table>
    
    <p>
		<%= Html.ActionLink("Populate Regex for ScrewTurn Wiki", "SetupForScrewTurn") %>
    </p>

</asp:Content>

