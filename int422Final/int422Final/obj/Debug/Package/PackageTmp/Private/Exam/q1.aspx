<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Exam/exam.Master" AutoEventWireup="true" CodeBehind="q1.aspx.cs" Inherits="int422Final.Private.Exam.q1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        Customer id:
        <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource3" DataTextField="l_name" DataValueField="l_name">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:int422_122a08ConnectionString %>" 
            SelectCommand="SELECT [l_name] FROM [v_Customer]"></asp:SqlDataSource>
&nbsp;&nbsp;Model id:
        <asp:DropDownList ID="ddlModel" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource2" DataTextField="model_id" 
            DataValueField="model_id">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:int422_122a08ConnectionString %>" 
            SelectCommand="SELECT [model_id] FROM [v_Vehicle_Model]">
        </asp:SqlDataSource>
        <br />
        Colour -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="tbColour" runat="server"></asp:TextBox>
        <br />
        Transmission -&nbsp;
        <asp:TextBox ID="tbTrans" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
    </div>
</asp:Content>
