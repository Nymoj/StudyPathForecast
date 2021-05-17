<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forecast.aspx.cs" Inherits="StudyPathForecast.Stats.Forecast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/ContentStyles.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentWrapper">
        <h2 class="pageTitle">עמוד החיזויים</h2>
        <p class="text">להגדרת מקצועות לחץ <asp:HyperLink runat="server" NavigateUrl="~/Stats/Questions/Preferences.aspx">כאן</asp:HyperLink></p>


        <p>אם כבר בחרת במגמה, נא לסמן  כאן</p>
        <asp:CheckBox runat="server" ID="hasChosenPath"></asp:CheckBox>

        <asp:DropDownList runat="server" ID="chosenPath">
            <asp:ListItem Value="Biology">ביולוגיה</asp:ListItem>
            <asp:ListItem Value="Physics">פיזיקה</asp:ListItem>
            <asp:ListItem Value="CS">מדעי מחשב</asp:ListItem>
            <asp:ListItem Value="Chemistry">כימיה</asp:ListItem>
        </asp:DropDownList>

        <asp:Button runat="server" ID="btnSubmitChosenPath" OnClick="btnSubmitChosenPath_Click" Text="עדכן מגמה"/>
        
        <h2>ניהול ציונים</h2>
        <asp:Panel runat="server" ID="gradeLinks"></asp:Panel>

        <p class="text" style="font-weight: bold;">לפי הנתונים שסיפקת\ה עד כה המגמה המתאימה לך היא: דוגמה</p>
    </div>
</asp:Content>
