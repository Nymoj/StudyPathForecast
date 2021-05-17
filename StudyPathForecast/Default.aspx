<%@ Page Title="דף הבית" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudyPathForecast._Default"%>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/ContentStyles.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contentWrapper">
        <h1 class="pageTitle">ברוך הבא לעמוד הבית</h1>

        <p class="text">
            שלום, שמי דניאל שלגונוב, והגעתם לעמוד הבית של הפרויקט שלי.<br />
            פרויקט זה מיועד לעזור לתלמידי חטיבת ביניים שעולים לשכבה עליונה בבה"ס.<br />
            תלמידים מוזמנים להרשם באתר על מנת להתחיל את התהליך.<br />
        </p>

        <h2 class="secondaryTitle">איך זה עובד?</h2>
        <p class="text">
            לאחר ההרשמה, יוכל התלמיד להקליד ולעקוב אחר נתוניו הלימודיים (כגון: ציוני מבחנים וציונים שנתיים)<br />
            כמו כן, יוכל התלמיד לבחור את המסלול (מגמות) המועדף ולקבל המלצות על סמך הנתונים בכדי להתקבל למסלול.<br />
            במהלך הזמן, תדע המערכת את המסלול האופטימלי בהתאם ליכולתיו של התלמיד.
        </p>

        <asp:Label runat="server" ID="p" ></asp:Label>
    </div>

</asp:Content>
