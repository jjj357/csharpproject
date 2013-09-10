<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Exam/exam.Master" AutoEventWireup="true" CodeBehind="q2.aspx.cs" Inherits="int422Final.Private.Exam.q2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource1" DataTextField="l_name" DataValueField="l_name" 
            onselectedindexchanged="ddl1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:int422_122a08ConnectionString %>" 
            SelectCommand="SELECT [l_name] FROM [v_Customer]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    </div>
</asp:Content>
