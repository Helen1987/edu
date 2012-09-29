<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="MvcAjaxForms.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Контакты
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Контакты</h2>
    <table>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Имя
            </td>
            <td>
                Фамилия
            </td>
            <td>
                Компания
            </td>
        </tr>
        <% foreach (Contact c in (List<Contact>)ViewData["Contacts"])
           {%>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "EditContact", new { id = c.Id }) %>
            </td>
            <td>
                <%= c.FirstName %>
            </td>
            <td>
                <%= c.LastName %>
            </td>
            <td>
                <%= c.Company %>
            </td>
        </tr>
        <% }%>
    </table>
</asp:Content>
