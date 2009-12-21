<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.RestRegex>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Regex
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Regex</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
			<p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <%= Html.CheckBox("IsEdit") %>
                <label for="IsEdit" class="inline">Is Edit</label>
                <%= Html.ValidationMessage("IsEdit", "*") %>
            </p>
            <p>
                <%= Html.CheckBox("IsHistory") %>
                <label for="IsHistory" class="inline">Is History</label>
                <%= Html.ValidationMessage("IsHistory", "*") %>
            </p>
            <p>
                <%= Html.CheckBox("IsDiff") %>
                <label for="IsDiff" class="inline">Is Diff</label>
                <%= Html.ValidationMessage("IsDiff", "*") %>
            </p>
            <p>
                <label for="MatchRegex">Match Regex:</label>
                <%= Html.TextBox("MatchRegex") %>
                <%= Html.ValidationMessage("MatchRegex", "*") %>
            </p>
            <p>
                <label for="ReplaceRegex">Replace Regex:</label>
                <%= Html.TextBox("ReplaceRegex") %>
                <%= Html.ValidationMessage("ReplaceRegex", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

