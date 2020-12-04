<%@ Page Title="הרשמה" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StudyPathForecast.Registration" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
    <link href="/Content/Registration.css" type="text/css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>הרשמה</h1>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser"
        CreateUserButtonText="הרשמה" UserNameLabelText="שם משתמש" PasswordLabelText="סיסמה"
        ConfirmPasswordLabelText="אימות סיסמה" EmailLabelText="כתובת אלקטרונית" CompleteSuccessText="משתמש נוצר בהצלחה">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder"></asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep Title=""></asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
