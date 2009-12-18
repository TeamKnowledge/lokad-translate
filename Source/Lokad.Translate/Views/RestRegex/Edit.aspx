<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.RestRegex>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Regex
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Regex</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="IsEdit">Is Edit:</label>
                <%= Html.CheckBox("IsEdit", Model.IsEdit) %>
                <%= Html.ValidationMessage("IsEdit", "*") %>
            </p>
            <p>
                <label for="IsHistory">Is History:</label>
                <%= Html.CheckBox("IsHistory", Model.IsHistory) %>
                <%= Html.ValidationMessage("IsHistory", "*") %>
            </p>
            <p>
                <label for="IsDiff">Is Diff:</label>
                <%= Html.CheckBox("IsDiff", Model.IsDiff) %>
                <%= Html.ValidationMessage("IsDiff", "*") %>
            </p>
            <p>
                <label for="MatchRegex">Match Regex:</label>
                <%= Html.TextBox("MatchRegex", Model.MatchRegex) %>
                <%= Html.ValidationMessage("MatchRegex", "*") %>
            </p>
            <p>
                <label for="ReplaceRegex">Replace Regex:</label>
                <%= Html.TextBox("ReplaceRegex", Model.ReplaceRegex) %>
                <%= Html.ValidationMessage("ReplaceRegex", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to Regex", "Index") %>
    </div>

</asp:Content>

