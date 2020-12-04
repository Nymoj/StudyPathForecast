<%@ Page Title="כניסה" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudyPathForecast.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>כניסה</h1>

    <asp:Login runat="server" ID="LoginWiz" LoginButtonText="כניסה" PasswordRequiredErrorMessage="חובה להזין חובה"
        RememberMeText="זכור אותי" UserNameLabelText="שם משתמש"
        UserNameRequiredErrorMessage="חובה להזין שם משתמש" PasswordLabelText="סיסמה"
        FailureText="ניסיון כניסה נכשל, תנסה שוב" TitleText="" OnLoggedIn="Login_LoggedIn">
    </asp:Login>

</asp:Content>
