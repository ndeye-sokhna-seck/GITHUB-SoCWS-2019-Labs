<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WS_Client._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h4 class=" display-4"> Bienvenue </h4><hr />
    <h6 class="text-muted">Selectionnez une ville et retrouvez toutes les stations !</h6>

    <div class="form form-inline my-5 px-3 row">
        <label for="choice" class="pr-1 col-lg-2">Choisir une ville</label><br>
        <asp:DropDownList ID="choice" runat="server"  class="form-control form-control-lg col-7 mr-1">
        </asp:DropDownList>      
        <asp:Button ID="SubmitButton" class="btn btn-success col-2"  runat="server" Text="Trouver" OnClick="SubmitButton_Click" />
    </div>

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
           <tr>
            <td>Statut</td>
            <td>Adresse</td>
            <td>Vélos disponibles</td>
            <td>Stands disponibles</td>
        </tr>
        <tr>
            <td>Statut</td>
            <td>Adresse</td>
            <td>Vélos disponibles</td>
            <td>Stands disponibles</td>
        </tr>
       </tbody>
        
    </table>

   <div class="text-danger"><%=Result%></div>

</asp:Content>

