<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<table>
    <tr>
        <td>
            Имя:
        </td>
        <td>
            <%=Html.TextBox("FirstName")%>
            <%=Html.ValidationMessage("FirstName")%>
        </td>
    </tr>
    <tr>
        <td>
            Фамилия:
        </td>
        <td>
            <%=Html.TextBox("LastName")%>
            <%=Html.ValidationMessage("LastName")%>
        </td>
    </tr>
    <tr>
        <td>
            Компания:
        </td>
        <td>
            <%=Html.TextBox("Company")%>
            <%=Html.ValidationMessage("Company")%>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <input type="submit" value="Сохранить" />
        </td>
    </tr>
</table>
