<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ScheduMail.DBModel.Mail>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditMail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditMail</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", Model.Id) %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="Subject">Subject:</label>
                <%= Html.TextBox("Subject", Model.Subject) %>
                <%= Html.ValidationMessage("Subject", "*") %>
            </p>
            <p>
                <label for="EMailContent">EMailContent:</label>
                <%= Html.TextBox("EMailContent", Model.EMailContent) %>
                <%= Html.ValidationMessage("EMailContent", "*") %>
            </p>
            <p>
                <label for="UserName">UserName:</label>
                <%= Html.TextBox("UserName", Model.UserName) %>
                <%= Html.ValidationMessage("UserName", "*") %>
            </p>
            <p>
                <label for="Password">Password:</label>
                <%= Html.TextBox("Password", Model.Password) %>
                <%= Html.ValidationMessage("Password", "*") %>
            </p>
            <p>
                <label for="CreatedBy">CreatedBy:</label>
                <%= Html.TextBox("CreatedBy", Model.CreatedBy) %>
                <%= Html.ValidationMessage("CreatedBy", "*") %>
            </p>
            <p>
                <label for="Created">Created:</label>
                <%= Html.TextBox("Created", String.Format("{0:g}", Model.Created)) %>
                <%= Html.ValidationMessage("Created", "*") %>
            </p>
            <p>
                <label for="ModifiedBy">ModifiedBy:</label>
                <%= Html.TextBox("ModifiedBy", Model.ModifiedBy) %>
                <%= Html.ValidationMessage("ModifiedBy", "*") %>
            </p>
            <p>
                <label for="Modified">Modified:</label>
                <%= Html.TextBox("Modified", String.Format("{0:g}", Model.Modified)) %>
                <%= Html.ValidationMessage("Modified", "*") %>
            </p>
            <p>
                <label for="LastSent">LastSent:</label>
                <%= Html.TextBox("LastSent", String.Format("{0:g}", Model.LastSent)) %>
                <%= Html.ValidationMessage("LastSent", "*") %>
            </p>
            <p>
                <label for="NextSend">NextSend:</label>
                <%= Html.TextBox("NextSend", String.Format("{0:g}", Model.NextSend)) %>
                <%= Html.ValidationMessage("NextSend", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

