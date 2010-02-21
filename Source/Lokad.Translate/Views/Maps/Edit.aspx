<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.Mapping>" %>
<%@ Import Namespace="Lokad.Translate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Mapping - Lokad.Translate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Mapping</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

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
                <%= Html.TextBox("Created", String.Format("{0:g}", Model.Created), new { disabled = "true" })%>
            </p>
            <p>
                <label for="Code">Code:</label>
                <%= Html.TextBox("Code", Model.Code, new { disabled = "true" })%>
            </p>
            <p>
                <label for="SourceUrl">Source Url:</label>
                <%= Html.CompactLink(Model.Page.Url)%>
            </p>
            <p>
                <label for="DestinationUrl">Destination Url:</label>
                <%= Html.TextBox("DestinationUrl", Model.DestinationUrl) %>
                <%= Html.ValidationMessage("DestinationUrl", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "List/" + Model.Code) %>
    </div>

</asp:Content>

