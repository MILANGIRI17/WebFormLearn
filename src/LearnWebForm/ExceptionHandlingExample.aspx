<%@ Page Title="Error Handling Example" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExceptionHandlingExample.aspx.cs" Inherits="LearnWebForm.ExceptionHandlingExample" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Exception Handling Example</h1>
    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
    <div class="form-group">
        <label>This should be a decimal: </label>
        <asp:TextBox ID="txtDecimal" CssClass="form-control" runat="server"/>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" CssClass="btn btn-success" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>