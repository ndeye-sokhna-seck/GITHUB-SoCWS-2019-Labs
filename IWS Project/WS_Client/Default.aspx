<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WS_Client._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="margin: 3em 0 3em 0">
        <div class="col-lg-6 col-sm-12">
            <div>
                <label for="Town">Ville</label>
                <asp:TextBox ID="Town"  CssClass="form-control" runat="server" AutoCompleteType="BusinessCity" OnTextChanged="Town_TextChanged"></asp:TextBox>
            </div>
            <div>
                <label for="NStation">N° Station</label>
                <asp:TextBox ID="NStation" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="SubmitButton" class="btn btn-outline-success mt-4"  runat="server" Text="Trouver" OnClick="SubmitButton_Click" />
        </div>
        <div class="col-lg-6 col-sm-12">
            <p class="mt-sm-3">Resultat</p>
            <textarea id="Results" class="form-control" cols="300" rows="5">
                <%=Result%>
            </textarea>
        </div>
    </div>


</asp:Content>
