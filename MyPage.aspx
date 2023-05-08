<%@ Page Title="My Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="LearnWebForm.MyPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Advanced ASP.NET Web Server Controls</h3>
    <h4>Create a list of events in a repeater from a calender control.</h4>
    <div class="form-group">
        <label>Event Name:</label>
        <asp:TextBox ID="txtEvent" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <label>Event Date:</label>
        <asp:Calendar ID="calenderEvents" runat="server" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnEvent" CssClass="btn btn-primary" runat="server" Text="Add Event" OnClick="btnEvent_Click" />
    </div>
    <h3>Events Repeater.</h3>
    <div>
        <asp:Repeater ID="rptEvents" runat="server">
            <ItemTemplate>
                <h4><%# DataBinder.Eval(Container.DataItem,"EventDate")%><small><%# DataBinder.Eval(Container.DataItem,"EventName")%></small></h4>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
