<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore.ViewModels.StoreIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse Genres
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Browse Genres</h2>
    
    <p>Select from <%: Model.NumberOfGenres %></p>

    <ul>
        <% foreach (string genreName in Model.Genres)
           { %>
           <li>
           <%: Html.ActionLink(genreName, "Browse", new { genre = genreName }, null) %> 
           
           </li>
        <% } %>
    </ul>
    <br/>

</asp:Content>
