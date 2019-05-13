<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Default.aspx.cs" Inherits="WS_Client._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h4 class=" display-4"> Bienvenue </h4><hr />
    <h6 class="text-muted">Selectionnez une ville et retrouvez toutes les stations !</h6>

    <div class="form form-inline my-5 px-3 row">
        <label for="choice" class="pr-1 col-lg-2">Choisir une ville</label><br>
        <asp:DropDownList ID="choice" runat="server" AutoPostBack="true" class="form-control form-control-lg col-7 mr-1" OnSelectedIndexChanged="getStationList">
        </asp:DropDownList>      
    </div>

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    <% if (Result.Count > 0)
            { %>
        <h6 class="text-muted"><%: choice.SelectedItem.Value %></h6>
        <table style="width: 100%;" class="table table-hover mb-5">
        <thead class="thead-dark">
            <tr>
            <th>Statut</th>
            <th>Adresse</th>
            <th>Vélos disponibles</th>
            <th>Stands disponibles</th>
            </tr>
        </thead>
            <tbody>
        <% foreach (var station in Result)
            { %>
            <tr>
                <td> <%: station.status %></td>
                <td><%: station.address %> </td>
                <td> <%: station.bikes %> </td>
                <td> <%: station.stands %> </td>
            </tr>
        <% }  %>
        </tbody>
        </table>
            <% } %>
</asp:Content>

