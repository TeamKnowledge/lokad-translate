<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create User</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="OpenId">OpenId:</label>
                <%= Html.TextBox("OpenId") %>
                <%= Html.ValidationMessage("OpenId", "*") %>
            </p>
            <p>
                <label for="DisplayName">DisplayName:</label>
                <%= Html.TextBox("DisplayName") %>
                <%= Html.ValidationMessage("DisplayName", "*") %>
            </p>
            <p>
                <label for="Code">Code:</label>
                <%= Html.TextBox("Code") %>
                <%= Html.ValidationMessage("Code", "*") %>
            </p>
            <p>
                <label for="IsManager">Is Manager:</label>
                <%= Html.CheckBox("IsManager") %>
                <%= Html.ValidationMessage("IsManager", "*") %>
            </p>
            <%= Html.ValidationSummary() %>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

