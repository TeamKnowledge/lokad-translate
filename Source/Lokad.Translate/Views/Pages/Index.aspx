<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Page>>" %>
<%@ Import Namespace="Lokad.Translate"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pages - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pages</h2>

    <% using (Html.BeginForm("Create", "Pages")) {%>

        <fieldset>
            <legend>Add page</legend>
            <p>
                <label for="Url">Url:</label>
                <%= Html.TextBox("Url") %>
                <%= Html.ValidationMessage("Url", "*") %>
                <input type="submit" value="Add" />
            </p>
            <%= Html.ValidationSummary() %>
        </fieldset>

    <% } %>
    
    <table>
        <tr>
            <th></th>
            <th>
                Url
            </th>
            <th>
                Last Updated
            </th>
            <th>
                Ignored
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
		<% if(item.IsIgnored) {%>
		<tr class="disabled">
		<% } else {  %>
        <tr>
        <% } %>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new {  id=item.Id }) %> |
                <%= Html.ActionLink("Mappings", "Mappings", new {  id=item.Id }) %> |
                <%= Html.ActionLink("Mark", "MarkAsUpdated", new {  id=item.Id }) %>
            </td>
            <td>
                <%= Html.CompactLink(item.Url) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.LastUpdated)) %>
            </td>
            <td>
                <%= item.IsIgnored ? "Yes" : "No" %>
            </td>
            <td>
                <%= Html.ActionLink("Delete", "Delete", new {  id=item.Id }) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

