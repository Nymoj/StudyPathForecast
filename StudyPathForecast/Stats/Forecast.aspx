<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forecast.aspx.cs" Inherits="StudyPathForecast.Stats.Forecast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/ContentStyles.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentWrapper">
        <h2 class="pageTitle">עמוד החיזויים</h2>
        <p class="text">להגדרת מקצועות לחץ <asp:HyperLink runat="server" NavigateUrl="~/Stats/Questions/Preferences.aspx">כאן</asp:HyperLink></p>
        
        <h2>ניהול ציונים</h2>
        <asp:Panel runat="server" ID="gradeLinks"></asp:Panel>

        <p class="text" style="font-weight: bold;">לפי הנתונים שסיפקת\ה עד כה המגמה המתאימה לך היא: דוגמה</p>
    </div>
</asp:Content>
