<%@ Page Title="Validation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidationExample.aspx.cs" Inherits="LearnWebForm.ValidationExample" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Validation Example</h1>
    
    <div class="form-group">
        <div class="form-text">
            *Fields marked with an asterik are required.
        </div>
    </div>
    <p class="bg-primary">
        <asp:Literal ID="ltMessage" runat="server"/>
        <asp:ValidationSummary ID="valSummaryForm" runat="server" CssClass="bg-error" ValidationGroup="valForm" DisplayMode="BulletList" HeaderText="Please fix the following errors."  />
    </p>

    <div class="form-group">
        <label>*Your Full Name:</label>
        <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ID="rqFullName" runat="server" ControlToValidate="txtFullName" ValidationGroup="valForm" CssClass="bg-error" ErrorMessage="*Full Name required." Display="Dynamic" />
    </div>

    <div class="form-group">
        <label>Your Nickname:</label>
        <asp:TextBox ID="txtNickname" CssClass="form-control" runat="server" />
    </div>

     <div class="form-group">
        <label>*Your Age:</label>
        <asp:TextBox ID="txtAge" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ID="rqAge" runat="server" ControlToValidate="txtAge" ValidationGroup="valForm" CssClass="bg-error" ErrorMessage="*Age required." Display="Dynamic" />
        <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" ValidationGroup="valForm" Type="Integer" MinimumValue="4" MaximumValue="120" CssClass="bg-error" ErrorMessage="*I find it hard to believe that is your age. Please enter your real age." Display="Dynamic" />
    </div>

    <div class="form-group">
        <label>*Name a Price (in USD):</label>
        <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ID="rqPrice" ControlToValidate="txtPrice" ValidationGroup="valForm" CssClass="bg-error" ErrorMessage="*Price is required." Display="Dynamic" runat="server" />
        <asp:CompareValidator ID="cvPrice" ControlToValidate="txtPrice" Operator="DataTypeCheck" Type="Currency" ValidationGroup="valForm" CssClass="bg-error" ErrorMessage="Please enter valid price." Display="Dynamic" runat="server" />
    </div>
    <div class="form-group">
        <label>*Your Email:</label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ID="rqEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="valForm" CssClass="bg-error" ErrorMessage="*Email required." Display="Dynamic" />
    </div>
    
    <div class="form-group">
        <asp:Button ID="btnSubmit" CssClass="btn btn-success" OnClick="btnSubmit_Click" Text="Submit" runat="server" ValidationGroup="valForm" CausesValidation="true" />
    </div>
</asp:Content>
