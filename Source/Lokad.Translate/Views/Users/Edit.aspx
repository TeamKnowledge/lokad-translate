<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit User
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
                <%= Html.TextBox("OpenId", Model.OpenId) %>
                <%= Html.ValidationMessage("OpenId", "*") %>
            </p>
            <p>
                <label for="DisplayName">Display Name:</label>
                <%= Html.TextBox("DisplayName", Model.DisplayName) %>
                <%= Html.ValidationMessage("DisplayName", "*") %>
            </p>
            <p>
                <label for="Code">Code:</label>
                <%= Html.TextBox("Code", Model.Code) %>
                <%= Html.ValidationMessage("Code", "*") %>
            </p>
            <p>
                <label for="IsManager">Is Manager:</label>
                <%= Html.CheckBox("IsManager", Model.IsManager) %>
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

