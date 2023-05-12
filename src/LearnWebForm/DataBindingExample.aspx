<%@ Page Title="Data Binding Example" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataBindingExample.aspx.cs" Inherits="LearnWebForm.DataBindingExample" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Data Binding Example</h1>
    <h4>
        <asp:Literal ID="ltError" runat="server" />
    </h4>

    <asp:GridView ID="gvColors" CssClass="table table-striped color-table" runat="server" AutoGenerateColumns="false" OnRowEditing="gvColors_RowEditing" OnRowDeleting="gvColors_RowDeleting" OnRowUpdating="gvColors_RowUpdating" OnRowCancelingEdit="gvColors_RowCancelingEdit">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnColorId" runat="server" Value='<%# Bind("ID")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Hex" HeaderText="Hex" />
            <asp:TemplateField HeaderText="Color Swatch">
                <ItemTemplate>
                    <div class="color-swatch">
                        <div class="color-swatch" style='<%# "background-color:#" + Eval("Hex") + ";" %>'></div>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" HeaderText="Edit" EditText="<i class='btn btn-warning fa-solid fa-pencil'></i>" UpdateText="<i class='btn btn-success fa-solid fa-check'></i>" CancelText="<i class='btn btn-danger fa-solid fa-xmark'></i>" />
            <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" DeleteText="<i class='btn btn-danger fa-solid fa-trash'></i>" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddRow" runat="server" Text="Add New Row" CssClass="btn btn-primary" OnClick="btnAddRow_Click" />

</asp:Content>
