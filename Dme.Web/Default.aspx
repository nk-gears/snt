<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dme.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-md-4">
            <h1>Внешние процессы</h1>
            <h3>Приемка</h3>
            <ul>
                <li><a runat="server" href="~/Todo">Заказы на размещение</a></li>
                <li><a runat="server" href="~/Todo">МХ-1</a></li>
                <li><a runat="server" href="~/Todo">Акты расхождений</a></li>
            </ul>
            <h3>Отгрузка</h3>
            <ul>
                <li><a runat="server" href="~/Todo">Заказы на отгрузку</a></li>
                <li><a runat="server" href="~/Todo">МХ-3</a></li>
                <li><a runat="server" href="~/Todo">Акты расхождений</a></li>
            </ul>
            <h3>Доставка</h3>
            <ul>
                <li><a runat="server" href="~/Todo">Задания на доставку</a></li>
                <li><a runat="server" href="~/Todo">Управление маршрутами</a></li>
                <li><a runat="server" href="~/Todo">ТТН</a></li>
                <li><a runat="server" href="~/Todo">Справочники</a></li>
            </ul>
        </div>
        <div class="col-md-4">
            <h1>Внутренние процессы</h1>
            <ul>
                <li><a runat="server" href="~/Todo">Акты инвентаризации</a></li>
                <li><a runat="server" href="~/Todo">Акты списания</a></li>
            </ul>
        </div>
        <div class="col-md-4">
            <h1>KPI</h1>
            <p>TODO...</p>
        </div>
        <div class="col-md-4">
            <h1>Документация</h1>
            <p>TODO...</p>
        </div>
    </div>
    <!--
    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    -->

</asp:Content>
