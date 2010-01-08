<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Lang>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Languages - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Languages</h2>
    <p>This page lists the target languages in which the source pages (as retrieved
    by the feeds) will be translated. We suggest to use short tokens here such as
    <em>fr</em>, <em>de</em> or <em>sh</em>. Once a source page gets updated,
    a matching work notification will appear for each targeted language.</p>
	<p><%= Html.Encode(ViewData["Message"]) %></p>
    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Code
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new {  id=item.Id }) %> 
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Code) %>
            </td>
            <td>
                <%= Html.ActionLink("Delete", "Delete", new {  id=item.Id }) %> 
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

