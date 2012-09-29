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
           
           <% if (ViewBag.Starred.Contains(genreName))  {  %>
                <img src="../../Content/Images/starred.png" alt="Starred element" />
           <% } %>
           </li>
        <% } %>
    </ul>
    <br/>
    <h5> <img src="../../Content/Images/starred.png" alt="Starred element" /> Starred genres 20% Off! </h5>

</asp:Content>
