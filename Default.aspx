<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaskManager._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Task Manager</h1>
        <p class="lead">A simple and clean task management application built with ASP.NET Web Forms.</p>
    </div>

    <asp:Panel ID="pnlDashboard" runat="server" Visible="false">
        <h3>Dashboard</h3>
        <br />

        <div class="row">
            <div class="col-md-3">
                <div class="card text-white bg-secondary mb-3">
                    <div class="card-body">
                        <h5 class="card-title">Total Tasks</h5>
                        <h2><asp:Label ID="lblTotal" runat="server" Text="0" /></h2>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-primary mb-3">
                    <div class="card-body">
                        <h5 class="card-title">To Do</h5>
                        <h2><asp:Label ID="lblToDo" runat="server" Text="0" /></h2>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-warning mb-3">
                    <div class="card-body">
                        <h5 class="card-title">In Progress</h5>
                        <h2><asp:Label ID="lblInProgress" runat="server" Text="0" /></h2>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-success mb-3">
                    <div class="card-body">
                        <h5 class="card-title">Done</h5>
                        <h2><asp:Label ID="lblDone" runat="server" Text="0" /></h2>
                    </div>
                </div>
            </div>
        </div>

        <br />
        <p>
            <asp:HyperLink ID="lnkViewTasks" runat="server" NavigateUrl="~/Tasks.aspx" CssClass="btn btn-primary">
                View All Tasks
            </asp:HyperLink>
            &nbsp;
            <asp:HyperLink ID="lnkAddTask" runat="server" NavigateUrl="~/AddTask.aspx" CssClass="btn btn-success">
                + Add New Task
            </asp:HyperLink>
        </p>
    </asp:Panel>

    <asp:Panel ID="pnlWelcome" runat="server" Visible="true">
        <div class="alert alert-info">
            Please <a href="~/Account/Login" runat="server">Log in</a> or 
            <a href="~/Account/Register" runat="server">Register</a> to start managing your tasks.
        </div>
    </asp:Panel>

</asp:Content>
