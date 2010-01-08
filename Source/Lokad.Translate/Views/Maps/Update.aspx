<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<Lokad.Translate.Entities.Mapping>" %>
<%@ Import Namespace="Lokad.Translate"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Update Mapping - Lokad.Translate</title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <table>
		<tr>
			<td valign="top">
			    <div class="page">

					<div id="main">
    <h2>Update (<%=Html.ActionLink("back", "List/" + Model.Code) %>)</h2>
    
    <p>
		<b>M1</b> <%= Html.FrameView("Src", Model.Page.Url)%> | 
		<%= Html.FrameView("Diff", (string)ViewData["DiffUrl"]) %> | 
		<%= Html.FrameView("Hist", (string)ViewData["HistUrl"])%> |
		<%= Html.FrameView("Dest", Model.DestinationUrl)%> |
		<%= Html.FrameView("Edit", (string)ViewData["EditUrl"])%> <br />
		
		<b>M2</b> <%= Html.SideView("Src", Model.Page.Url)%> | 
		<%= Html.SideView("Diff", (string)ViewData["DiffUrl"]) %> | 
		<%= Html.SideView("Hist", (string)ViewData["HistUrl"])%> |
		<%= Html.SideView("Dest", Model.DestinationUrl)%> |
		<%= Html.SideView("Edit", (string)ViewData["EditUrl"])%> 
    </p>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Code:
            <%= Html.Encode(Model.Code) %>
        </p>
        <p>
            U:
            <%= Html.Encode(Model.Page.LastUpdated) %>
        </p>
        <p>
            Source:
            <%= Html.CompactLink(Model.Page.Url) %>
        </p>
        <p>
            Dest:
            <%= Html.CompactLink(Model.DestinationUrl) %>
        </p>
        <p>
			Version:
			<%= Html.Encode(Model.Version) %>
        </p>
    </fieldset>
    
    <% using (Html.BeginForm("Submit", "Maps", new { id = Model.Id})) {%>

    <fieldset>
        <legend>Record Update</legend>
        <% if (string.IsNullOrEmpty(Model.DestinationUrl)) { %>
        <p>
            <label for="DestinationUrl">Destination Url:</label>
            <%= Html.TextBox("DestinationUrl", "" )%>
            <%= Html.ValidationMessage("DestinationUrl", "*") %>
        </p>
        <%} %>
        <p>
            <label for="WordCount" style="display:inline">Word Count:</label>
            <%= Html.TextBox("WordCount", 0, new { style = "width:50px" })%>
            <%= Html.ValidationMessage("WordCount", "*") %>
        </p>
        <p>
            <label for="Created" style="display:inline">Version:</label>
            <%= Html.TextBox("Version", "", new { style = "width:50px" })%>
            <%= Html.ValidationMessage("Version", "*") %>
        </p>
        <%= Html.ValidationSummary() %>
        <p>
            <input type="submit" value="Submit" />
        </p>
        <p> <%= Html.Encode(ViewData["Message"]) %></p>
    </fieldset>

    <% } %>
    
    <span style="font-size:200%">
		<%=Html.ActionLink("Next", "Next", new { id = Model.Id }) %>
	</span>
						<div id="footer">
						</div>
					</div>
				</div>
			</td>
			<td>
				<iframe id="SideFrame" src ="<%= Model.Page.Url %>" width="1024px" height="700px" scrolling="auto">
					<p>Your browser does not support iframes.</p>
				</iframe>
			</td>
		</tr>
    </table>

</body>
</html>



