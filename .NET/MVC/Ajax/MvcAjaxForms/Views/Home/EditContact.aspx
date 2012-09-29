<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcAjaxForms.Models.Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    �������������� ��������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function ajaxSuccess() {
            alert('������ ���������!');
        }

        function ajaxFailure() {
            alert('��������� ������!');
        }

        function ajaxOnComplete(result) {
            alert('��� ������!');
        }

    </script>

    <h2>
        �������������� ��������</h2>
    <% using (Ajax.BeginForm(new AjaxOptions { OnSuccess = "ajaxSuccess", OnFailure = "ajaxFailure", OnComplete = "ajaxOnComplete" }))
       { %>
    <% = Ajax.ActionLink("�������� �����", "NewData", new AjaxOptions { UpdateTargetId = "ajaxDiv"}) %>
    <div id="ajaxDiv">
        <% Html.RenderPartial("EditForm"); %>
    </div>
    <% } %>
</asp:Content>
