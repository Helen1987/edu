<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<table>
    <tr>
        <td>
            ���:
        </td>
        <td>
            <%=Html.TextBox("FirstName")%>
            <%=Html.ValidationMessage("FirstName")%>
        </td>
    </tr>
    <tr>
        <td>
            �������:
        </td>
        <td>
            <%=Html.TextBox("LastName")%>
            <%=Html.ValidationMessage("LastName")%>
        </td>
    </tr>
    <tr>
        <td>
            ��������:
        </td>
        <td>
            <%=Html.TextBox("Company")%>
            <%=Html.ValidationMessage("Company")%>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <input type="submit" value="���������" />
        </td>
    </tr>
</table>
