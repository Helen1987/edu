<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcAjaxForms.Models.Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Редактирование контакта
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function ajaxSuccess() {
            alert('Данные сохранены!');
        }

        function ajaxFailure() {
            alert('Произошла ошибка!');
        }

        function ajaxOnComplete(result) {
            alert('Все пришло!');
        }

    </script>

    <h2>
        Редактирование контакта</h2>
    <% using (Ajax.BeginForm(new AjaxOptions { OnSuccess = "ajaxSuccess", OnFailure = "ajaxFailure", OnComplete = "ajaxOnComplete" }))
       { %>
    <% = Ajax.ActionLink("Обновить форму", "NewData", new AjaxOptions { UpdateTargetId = "ajaxDiv"}) %>
    <div id="ajaxDiv">
        <% Html.RenderPartial("EditForm"); %>
    </div>
    <% } %>
</asp:Content>
