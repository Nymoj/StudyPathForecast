<%@ Page Title="הרשמה" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StudyPathForecast.Registration" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <link href="/Content/Forms.css" type="text/css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="formWrapper">
        <h1>הרשמה</h1>

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
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtUsername" ErrorMessage="חובה למלא שם משתמש" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="דואר אלקטרוני" CssClass="formLabel"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" CssClass="roundInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="חובה למלא כתובת אלקטרונית" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="pwdPassword" ErrorMessage="חובה למלא סיסמה" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="אימות סיסמה" CssClass="formLabel"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" ID="pwdConfirmPassword" CssClass="roundInput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="pwdConfirmPassword" ErrorMessage="חובה לאמת סיסמה" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" Text="הרשמה" ID="btnSubmit" CssClass="btnSubmit" OnClick="RegisterUser"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
