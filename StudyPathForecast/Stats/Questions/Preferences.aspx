<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="StudyPathForecast.Stats.Questions.Preferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/ContentStyles.css" type="text/css" rel="stylesheet"/>
    <link href="../../Content/Forms.css" type="text/css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentWrapper">
        <h1 class="pageTitle">שאלום העדיפויות</h1>
        <table class="table">
            <tr>
                <td>האם אתה לומד מתמטיקה 5 יחידות?</td>
                <td>
                    <!--<asp:RadioButton runat="server" GroupName="Studies5PointsMath" Text="כן"/>
                    <asp:RadioButton runat="server" GroupName="Studies5PointsMath" Text="לא"/>-->
                    <asp:RadioButtonList runat="server" ID="Math5" RepeatDirection="Horizontal" OnSelectedIndexChanged="Math5_SelectedIndexChanged">
                        <asp:ListItem>כן</asp:ListItem>
                        <asp:ListItem>לא</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>האם אתה לומד מתמטיקה 4 יחידות?</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="Math4" RepeatDirection="Horizontal" OnSelectedIndexChanged="Math4_SelectedIndexChanged">
                        <asp:ListItem>כן</asp:ListItem>
                        <asp:ListItem>לא</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>האם אתה לומד אנגלית 5 יחידות?</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="English5" RepeatDirection="Horizontal" OnSelectedIndexChanged="English5_SelectedIndexChanged">
                        <asp:ListItem>כן</asp:ListItem>
                        <asp:ListItem>לא</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>האם אתה לומד אנגלית 4 יחידות?</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="English4" RepeatDirection="Horizontal" OnSelectedIndexChanged="English4_SelectedIndexChanged">
                        <asp:ListItem>כן</asp:ListItem>
                        <asp:ListItem>לא</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>האם אתה לומד פיזיקה?</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="Physics" RepeatDirection="Horizontal" OnSelectedIndexChanged="Physics_SelectedIndexChanged">
                        <asp:ListItem>כן</asp:ListItem>
                        <asp:ListItem>לא</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>האם אתה לומד אומנות?</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="Art" RepeatDirection="Horizontal" OnSelectedIndexChanged="Art_SelectedIndexChanged">
                        <asp:ListItem>כן</asp:ListItem>
                        <asp:ListItem>לא</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><p style="color:red;">זהירות! בעת סימון "לא" במקצועות הנלמדים, כל הציונים שהוזנו באותו מקצוע ימחקו</p></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" Text="שמור" CssClass="btnSubmit" OnClick="Submit_Click"/></td>
            </tr>
        </table>
    </div>
</asp:Content>
