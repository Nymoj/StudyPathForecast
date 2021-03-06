<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="StudyPathForecast.Profile.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/ContentStyles.css" rel="stylesheet" type="text/css"/>
    <link href="../Content/Profile.css" rel="stylesheet" type="text/css"/>
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
                    <%: user.Email %>
                </td>
            </tr>
            <tr>
                <td>
                    תאריך הרשמה:
                </td>
                <td>
                    <%: String.Format("{0}.{1}.{2}", user.CreatedAt.Day, user.CreatedAt.Month, user.CreatedAt.Year) %>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" Text="יציאה מהמשתמש" ID="btnLogout" OnClick="btnLogout_Click"/>
                </td>
            </tr>
        </table>
        <p>רוצה לשנות את נתוני הפרופיל? <asp:HyperLink runat="server" NavigateUrl="~/Profile/EditProfile.aspx">ערוך אותו!</asp:HyperLink></p>
    </div>
</asp:Content>
