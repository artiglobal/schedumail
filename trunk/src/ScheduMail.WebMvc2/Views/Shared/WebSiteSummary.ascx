<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ScheduMail.Core.Domain.WebSite>" %>
<div class="item">
    <h3>
        <%= Model.SiteName %></h3>
    <%= Model.Template %>
    <%= Model.ModifiedBy %>
</div>
