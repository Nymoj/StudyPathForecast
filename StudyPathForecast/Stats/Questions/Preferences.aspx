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
                <td>האם אתה אוהב מתמטיקה?</td>
                <td>
                    <asp:RadioButton runat="server" GroupName="LikesMath" Text="כן"/>
                    <asp:RadioButton runat="server" GroupName="LikesMath" Text="לא"/>
                </td>
            </tr>
            <tr>
                <td>האם אתה אוהב פיזיקה?</td>
                <td>
                    <asp:RadioButton runat="server" GroupName="LikesPhysics" Text="כן"/>
                    <asp:RadioButton runat="server" GroupName="LikesPhysics" Text="לא"/>
                </td>
            </tr>
            <tr>
                <td>האם אתה אוהב ביולוגיה?</td>
                <td>
                    <asp:RadioButton runat="server" GroupName="LikesBiology" Text="כן"/>
                    <asp:RadioButton runat="server" GroupName="LikesBiology" Text="לא"/>
                </td>
            </tr>
            <tr>
                <td>האם אתה אוהב כימיה?</td>
                <td>
                    <asp:RadioButton runat="server" GroupName="LikesChemistry" Text="כן"/>
                    <asp:RadioButton runat="server" GroupName="LikesChemistry" Text="לא"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" Text="שמור" CssClass="btnSubmit"/></td>
            </tr>
        </table>
    </div>
</asp:Content>
