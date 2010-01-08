<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit User - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit User</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", Model.Id, new { disabled = "true" })%>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="Created">Created:</label>
                <%= Html.TextBox("Created", Model.Created, new { disabled = "true" }) %>
                <%= Html.ValidationMessage("Created", "*") %>
            </p>
            <p>
                <label for="OpenId">OpenId:</label>
                <%= Html.TextBox("OpenId", Model.OpenId) %> (don't forget the trailing slash at the end)
                <%= Html.ValidationMessage("OpenId", "*") %>
            </p>
            <p>
                <label for="DisplayName">Display Name:</label>
                <%= Html.TextBox("DisplayName", Model.DisplayName) %>
                <%= Html.ValidationMessage("DisplayName", "*") %>
            </p>
            <p>
                <label for="Code">Language Code:</label>
                <%= Html.TextBox("Code", Model.Code) %> (default language section displayed in the <em>Pending work</em> tab)
                <%= Html.ValidationMessage("Code", "*") %>
            </p>
            <p>
                <%= Html.CheckBox("IsManager", Model.IsManager) %>
                <label for="IsManager" class="inline">Is Manager</label>
                <%= Html.ValidationMessage("IsManager", "*") %>
            </p>
            <%= Html.ValidationSummary() %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to users", "Index") %>
    </div>

</asp:Content>

