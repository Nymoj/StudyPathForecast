<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="StudyPathForecast.Profile.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/ContentStyles.css" rel="stylesheet" type="text/css"/>
    <link href="../Content/Profile.css" rel="stylesheet" type="text/css"/>
    <link href="../Content/Forms.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentWrapper">
        <h1 class="pageTitle">פרופיל שלי</h1>

        <table class="profileTable">
            <tr>
                <td>
                    שם משתמתש:
                </td>
                <td>
                    הדגמה
                </td>
            </tr>
            <tr>
                <td>
                    דואר אלקטרוני: 
                </td>
                <td>
                    <asp:TextBox CssClass="roundInput" runat="server" TextMode="Email" ID="txtNewEmail"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    סיסמה חדשה:
                </td>
                <td>
                    <asp:TextBox CssClass="roundInput" runat="server" TextMode="Email" ID="pwdPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    סיסמה נוכחית:
                </td>
                <td>
                    <asp:TextBox CssClass="roundInput" runat="server" TextMode="Email" ID="TextBox1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" CssClass="btnSubmit" Text="שמור"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
