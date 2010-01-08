<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Mapping>>" %>
<%@ Import Namespace="Lokad.Translate"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pending work - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(ViewData["LanguageCode"])%> - Pending work </h2>
	<p>The element that link a source page (original document) with its destination page
	(translated document) is called a <b>mapping</b> in the Lokad.Translate terminology. 
	The mappings that need attention are displayed in bold here below. Click the <b>Update</b>
	button associated to a mapping to get a view of both the original and destination document.</p>
    <table>
        <tr>
            <th></th>
            <th>
                Source
            </th>
            <th>
                Destination
            </th>
            <th>
				Source Updated
            </th>
            <th>
				Dest. Updated
            </th>
            <th>
				Version
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
		<% if (item.Page.LastUpdated > item.LastUpdated || 
				string.IsNullOrEmpty(item.DestinationUrl) ||
				string.IsNullOrEmpty(item.Version)) { %>
		<tr style="font-weight:bold">
		<% } else { %> <tr> <% } %>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.Id })%>
            </td>
            <td>
                <%= Html.CompactLink(item.Page.Url)%>
            </td>
            <td>
				<%= Html.CompactLink(item.DestinationUrl)%>
            </td>
            <td>
				<%= Html.Encode(item.Page.LastUpdated)%>
            </td>
            <td>
				<%= Html.Encode(item.LastUpdated)%>
            </td>
            <td>
				<%= Html.Encode(item.Version)%>
            </td>
            <td>
				<%= Html.ActionLink("Update", "Update", new { id = item.Id }) %>
            </td>
        </tr>
        <% } %>
    </table>

</asp:Content>

