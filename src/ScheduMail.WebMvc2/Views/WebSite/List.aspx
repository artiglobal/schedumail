<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ScheduMail.Core.Domain.WebSite>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Web Sites</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Web Site Name
            </th>
            <th>
                Template
            </th>
        </tr>
        <% foreach (var webSite in Model)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = webSite.Id })%>
                |
                <%= Html.ActionLink("Delete", "Delete", new { id = webSite.Id })%>
            </td>
            <td>
                <%= Html.Encode(webSite.SiteName) %>
            </td>
            <td>
                <%= Html.Encode(webSite.Template)%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
