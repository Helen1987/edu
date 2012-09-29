<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcMusicStore.Models.ActionLog>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Action Log
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Action Log</h2>

    <table>
        <tr>
            <th>
                Action Log Id
            </th>
            <th>
                Controller
            </th>
            <th>
                Action
            </th>
            <th>
                IP
            </th>
            <th>
                Date/Time
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.ActionLogId %>
            </td>
            <td>
                <%: item.Controller %>
            </td>
            <td>
                <%: item.Action %>
            </td>
            <td>
                <%: item.IP %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DateTime) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

