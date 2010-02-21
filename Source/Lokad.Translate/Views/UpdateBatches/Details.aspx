<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lokad.Translate.Entities.Update>>" %>
<%@ Import Namespace="Lokad.Translate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Job details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Job details - <%= ViewData["BatchId"] %> (<%= Html.ActionLink("Back", "Index") %>)</h2>

	<p>
		<b>Translator:</b> <%= ViewData["Translator"] %>
	</p>

    <table>
        <tr>
            <th>
                Id
            </th>
            <th>
                Created
            </th>
            <th>
				Destination
            </th>
            <th>
                WordCount
            </th>
            <th>
                Version
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Created)) %>
            </td>
            <td>
                <%= Html.CompactLink(item.Mapping.DestinationUrl)%>
            </td>
            <td>
                <%= Html.Encode(item.WordCount) %>
            </td>
            <td>
                <%= Html.Encode(item.Version) %>
            </td>
        </tr>
    
    <% } %>

    </table>

	<p>
		<b>Total word count:</b> <%= ViewData["WordCount"] %> <br />
		<b>Is paid:</b> <%= ViewData["IsPaid"]  %>
	</p>
	
	<p>
        <%= Html.ActionLink("Toggle IsPaid", "ToggleIsPaid", 
        	new { id = ViewData["BatchId"] }) %>
    </p>
</asp:Content>

