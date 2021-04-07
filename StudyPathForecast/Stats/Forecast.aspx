<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forecast.aspx.cs" Inherits="StudyPathForecast.Stats.Forecast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/ContentStyles.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentWrapper">
        <h2 class="pageTitle">עמוד החיזויים</h2>
        <p class="text">להגדרת מקצועות מועדפים לחץ <asp:HyperLink runat="server" NavigateUrl="~/Stats/Questions/Preferences.aspx">כאן</asp:HyperLink></p>
        <table class="table" style="border: none;">
            <thead>
                <tr style="font-weight: bold;">
                    <td>מקצוע</td>
                    <td>ממוצע</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>מתמטיקה</td>
                    <td>דוגמה</td>
                </tr>
                <tr>
                    <td>מתמטיקה</td>
                    <td>דוגמה</td>
                </tr>
                <tr>
                    <td>מתמטיקה</td>
                    <td>דוגמה</td>
                </tr>
                <tr>
                    <td>מתמטיקה</td>
                    <td>דוגמה</td>
                </tr>
            </tbody>
        </table>
        <p class="text" style="font-weight: bold;">לפי הנתונים שסיפקת\ה עד כה המגמה המתאימה לך היא: דוגמה</p>
    </div>
</asp:Content>
