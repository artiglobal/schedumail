<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ScheduMail.Core.Domain.WebSite>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
             
             <%= Html.Hidden("Id", Model.Id)%>
                         
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SiteName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SiteName) %>
                <%= Html.ValidationMessageFor(model => model.SiteName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Template) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Template) %>
                <%= Html.ValidationMessageFor(model => model.Template) %>
            </div>
                                   
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "List") %>
    </div>

</asp:Content>

