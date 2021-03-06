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
                    <%: user.Username %>
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
                    <asp:TextBox CssClass="roundInput" runat="server" TextMode="Password" ID="pwdNewPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    סיסמה נוכחית:
                </td>
                <td>
                    <asp:TextBox CssClass="roundInput" runat="server" TextMode="Password" ID="pwdPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="errorMessage" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" CssClass="btnSubmit" Text="שמור" ID="btnSaveChanges" OnClick="btnSaveChanges_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
