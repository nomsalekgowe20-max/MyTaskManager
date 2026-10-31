<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TaskManager.AddTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add New Task</h2>
    <hr />

    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtTitle" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle"
                    CssClass="text-danger" ErrorMessage="Title is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtDescription" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlStatus" CssClass="col-md-2 control-label">Status</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                    <asp:ListItem>To Do</asp:ListItem>
                    <asp:ListItem>In Progress</asp:ListItem>
                    <asp:ListItem>Done</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlPriority" CssClass="col-md-2 control-label">Priority</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control">
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem Selected="True">Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtDueDate" CssClass="col-md-2 control-label">Due Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnSave" runat="server" Text="Save Task" CssClass="btn btn-success" OnClick="btnSave_Click" />
                &nbsp;
                <asp:HyperLink ID="lnkCancel" runat="server" NavigateUrl="~/Tasks.aspx" CssClass="btn btn-default">Cancel</asp:HyperLink>
            </div>
        </div>
    </div>

</asp:Content>
