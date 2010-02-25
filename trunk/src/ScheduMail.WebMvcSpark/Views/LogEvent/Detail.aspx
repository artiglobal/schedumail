<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ScheduMail.Core.Domain.LogEvent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detail</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            LogEventTypeId:
            <%= Html.Encode(Model.LogEventTypeId) %>
        </p>
        <p>
            Message:
            <%= Html.Encode(Model.Message) %>
        </p>
        <p>
            SenderUserName:
            <%= Html.Encode(Model.SenderUserName) %>
        </p>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            CreatedBy:
            <%= Html.Encode(Model.CreatedBy) %>
        </p>
        <p>
            Created:
            <%= Html.Encode(String.Format("{0:g}", Model.Created)) %>
        </p>
        <p>
            ModifiedBy:
            <%= Html.Encode(Model.ModifiedBy) %>
        </p>
        <p>
            Modified:
            <%= Html.Encode(String.Format("{0:g}", Model.Modified)) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

