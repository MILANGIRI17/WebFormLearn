<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LearnWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:Button ID="addCustomer" rkunat="server" OnClick="addCustomerClicked" Text="Add Customers" />--%>
    <%--<asp:Button ID="showCustomer" runat="server" OnClick="showCustomer_Click" Text="Show Customers" />--%>
    <main>

        <asp:Button ID="btnRedirect" runat="server" OnClick="btnRedirect_Click" Text="Redirect to About Page" />
        <br />
        <asp:Label runat="server" ID="HelloWorldLabel" />
        <br />
        <br />
        <asp:TextBox runat="server" ID="TextInput" />
        <asp:Button runat="server" ID="GreetButton" OnClick="GreetButton_Click" Text="Say Hello!" />
        <br />
        <br />

        <asp:DropDownList runat="server" ID="GreetList" AutoPostBack="true" OnSelectedIndexChanged="GreetList_SelectedIndexChanged">
            <asp:ListItem Value="no one">No one</asp:ListItem>
            <asp:ListItem Value="world">World</asp:ListItem>
            <asp:ListItem Value="universe">Universe</asp:ListItem>
        </asp:DropDownList>
    </main>
</asp:Content>
