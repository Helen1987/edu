<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcMusicStore.Models.Album>" %>

<script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

<p>
    <%: Html.LabelFor(model => model.Title) %>
    <%: Html.TextBoxFor(model => model.Title) %>
    <%: Html.ValidationMessageFor(model => model.Title) %>
</p>            
<p>
    <%: Html.LabelFor(model => model.Price) %>
    <%: Html.TextBoxFor(model => model.Price) %>
    <%: Html.ValidationMessageFor(model => model.Price) %>
</p>            
<p>
    <%: Html.LabelFor(model => model.AlbumArtUrl) %>
    <%: Html.TextBoxFor(model => model.AlbumArtUrl) %>
    <%: Html.ValidationMessageFor(model => model.AlbumArtUrl) %>
</p>            
<p>
    <%: Html.LabelFor(model => model.Artist) %>
    <%: Html.DropDownList("ArtistId", (SelectList) ViewData["Artists"]) %>
</p>            
<p>
    <%: Html.LabelFor(model => model.Genre) %>
    <%: Html.DropDownList("GenreId", (SelectList) ViewData["Genres"]) %>
</p>            


