<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Users - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Users</h2>
	<p>This page gathers the users that are granted access rights to Lokad.Translate.
	<b>Manager</b>s are granted administrative rights, basically all the options available
	through the <b>Manage</b> tab. Typically each translators should have its own OpenID 
	access.</p>
    <table>
        <tr>
            <th></th>
            <th>
                OpenId
            </th>
            <th>
                Display Name
            </th>
            <th>
                Code
            </th>
            <th>
                Is Manager
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Id}) %> 
            </td>
            <td>
                <%= Html.Encode(item.OpenId) %>
            </td>
            <td>
                <%= Html.Encode(item.DisplayName) %>
            </td>
            <td>
                <%= Html.Encode(item.Code) %>
            </td>
            <td>
                <%= Html.Encode(item.IsManager) %>
            </td>
            <td>
                <%= Html.ActionLink("Delete", "Delete", new { id=item.Id}) %> 
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

