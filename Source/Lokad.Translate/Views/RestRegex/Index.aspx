<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.RestRegex>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Regex - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Regex</h2>
    
    <p>Lokad.Translate lets you customize how your translators will
    interact the 3rd party web app being translated. The regex patterns
    are used to transform the input URL (the URL of the pages used as
    source) into REST API calls.</p>
    
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
                Type
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
                <% if(item.IsCode) { %>
					Code
                <% } else if(item.IsEdit) { %>
					Edit
                <% } else if(item.IsHistory) { %>
					History
                <% } else { %>
					Diff
                <% } %>
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

