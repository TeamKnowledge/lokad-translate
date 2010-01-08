<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create User - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create User</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="OpenId">OpenId:</label>
                <%= Html.TextBox("OpenId") %> (don't forget the trailing slash at the end)
                <%= Html.ValidationMessage("OpenId", "*") %>
            </p>
            <p>
                <label for="DisplayName">Display Name:</label>
                <%= Html.TextBox("DisplayName") %>
                <%= Html.ValidationMessage("DisplayName", "*") %>
            </p>
            <p>
                <label for="Code">Language Code:</label> 
                <%= Html.TextBox("Code") %> (default language section displayed in the <em>Pending work</em> tab)
                <%= Html.ValidationMessage("Code", "*") %>
            </p>
            <p>
                <%= Html.CheckBox("IsManager") %>
                <label for="IsManager" class="inline">Is Manager</label>
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

