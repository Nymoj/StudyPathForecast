﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Math4Points.aspx.cs" Inherits="StudyPathForecast.Stats.Grades.Math4Points" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/ContentStyles.css" rel="stylesheet" type="text/css"/>
    <link href="/Content/Forms.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentWrapper">
        <h2 class="pageTitle">ציוני מתמטיקה 5 יח'</h2>
        
        <div class="gradeInputWrapper">
            <asp:Label runat="server" ID="errorMessage"></asp:Label>
            <asp:TextBox runat="server" ID="txtGrade" CssClass="roundInput"></asp:TextBox>
            <asp:Button runat="server" ID="btnSubmitGrade" Text="שלח ציון" CssClass="btnSubmit" OnClick="btnSubmitGrade_Click"/>
        </div>

        <asp:GridView runat="server" ID="gvGrades" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField DataField="Grade" HeaderText="ציון" />
                <asp:BoundField DataField="Date" HeaderText="תאריך" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>