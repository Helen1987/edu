<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MvcMusicStore.Pages.MyBasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Browse Albums
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div>
<%= this.MessageService.Message %>
<br />
<img alt="<%: this.MessageService.Message %>"src="<%: this.MessageService.ImageUrl %>" />
</div>

    <div class="genre">
        <p><strong><%: Model.Genre.Name %>:</strong> <%: Model.Genre.Description %></p>

        <ul id="album-list">
            <% foreach (var album in Model.Albums) { %>

            <li>
                <a href="<%: Url.Action("Details", new { id = album.AlbumId }) %>">
                    <img alt="<%: album.Title %>" src="<%: album.AlbumArtUrl %>" />
                    <span><%: album.Title %></span>
                </a>
            </li>

            <% } %>
        </ul>

    </div>

</asp:Content>
