<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page - Lokad.Translate
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Translator manager</h2>
    <p>
        The primary purpose of Lokad.Translator is to speed-up the localization of
        a web site on an ongoing basis. It facilitates the management of a team of 
        translators as well speeding up the efforts of the translators.</p>
    <p>
        The process is called <b>continous localization</b>
        as opposed to <b>one-shot localization</b>.
    </p>
    <p>
		Lokad.Translate automates the tracking of:
    </p>
    <ul>
		<li>Changes on the original website.</li>
		<li>Mappings between targets and localized versions.</li>
		<li>Updates brought to localized versions.</li>
		<li>Jobs that gather a list of updates (to get translators paid).</li>
    </ul>
    
    <p>Designed by <a href="http://www.lokad.com/">Lokad</a> (c), check also the <a href="http://code.google.com/p/lokad-translate/">project page</a>.</p>
</asp:Content>
