<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="TaskManager.Tasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>My Tasks</h2>
    <p>
        <asp:HyperLink ID="lnkAddTask" runat="server" NavigateUrl="~/AddTask.aspx" CssClass="btn btn-primary">
            + Add New Task
        </asp:HyperLink>
    </p>
    <br />

    <asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="False" 
    CssClass="table table-striped table-hover table-bordered" 
    DataKeyNames="Id"
    OnRowCommand="gvTasks_RowCommand"
    OnRowDataBound="gvTasks_RowDataBound"
    EmptyDataText="No tasks found. Click 'Add New Task' to create one.">

    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" />

        <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' CssClass="badge" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Priority">
            <ItemTemplate>
                <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority") %>' CssClass="badge" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:dd MMM yyyy}" />
        <asp:BoundField DataField="CreatedDate" HeaderText="Created" DataFormatString="{0:dd MMM yyyy}" />

        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" 
                    CommandName="EditTask" CommandArgument='<%# Eval("Id") %>' 
                    CssClass="btn btn-sm btn-outline-primary" />
                &nbsp;
                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" 
                    CommandName="DeleteTask" CommandArgument='<%# Eval("Id") %>' 
                    CssClass="btn btn-sm btn-outline-danger"
                    OnClientClick="return confirm('Are you sure you want to delete this task?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>