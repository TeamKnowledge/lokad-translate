<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.UpdateBatch>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Jobs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Jobs</h2>
	<p>A <b>job</b> represents a set of elementary work updates from 
	a translator. Jobs are useful to keep track of the work of translators 
	(and getting them paid too), as they aggregates the fine-grained 
	work update details.</p>
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
                Word Count
            </th>
            <th>
				Is Paid
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

