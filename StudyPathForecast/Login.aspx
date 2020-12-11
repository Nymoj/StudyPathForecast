<%@ Page Title="כניסה" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudyPathForecast.Login" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <link href="/Content/Forms.css" type="text/css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="formWrapper">
        <h1>כניסה</h1>

        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="שם משתמש" CssClass="formLabel"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUsername" CssClass="roundInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="סיסמה" CssClass="formLabel"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" ID="pwdPassword" CssClass="roundInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" Text="כניסה" ID="btnSubmit" CssClass="btnSubmit"/>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
