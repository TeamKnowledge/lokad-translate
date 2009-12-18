<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <b><%= Html.Encode(Page.User.Identity.Name) %></b>
        [ <%= Html.ActionLink("Logout", "Logout", "Account") %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Login", "Login", "Account") %> ]
<%
    }
%>
