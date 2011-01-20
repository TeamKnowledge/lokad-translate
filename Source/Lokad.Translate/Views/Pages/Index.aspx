<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Page>>" %>
<%@ Import Namespace="Lokad.Translate"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pages - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pages</h2>
	<p>The table below gathers all the <b>sources</b> that should be translated into
	the target languages. Those pages are automatically retrieved through the <b>feeds</b>
	(if you have setup a web feed in the <b>Manage &raquo; Feeds</b> tab). You can also
	manually add pages and mark then as <em>updated</em>. Translators get automatically
	notified when new pages or updated pages need their attention.
	</p>
	
    <% using (Html.BeginForm("Create", "Pages")) {%>

        <fieldset>
            <legend>Add page</legend>
            <p>
                <label for="Url">Url:</label>
                <%= Html.TextBox("Url", String.Empty, new { @class = "editbox", size = 100} ) %>
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

