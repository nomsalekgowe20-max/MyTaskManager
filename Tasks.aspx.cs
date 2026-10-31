using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using TaskManager.Models;

namespace TaskManager
{
    public partial class Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only allow logged-in users
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }

            if (!IsPostBack)
            {
                BindTasks();


            }
        }

        private void BindTasks()
        {
            string userId = User.Identity.GetUserId();

            using (var db = new ApplicationDbContext())
            {
                var tasks = db.Tasks
                              .Where(t => t.UserId == userId)
                              .OrderByDescending(t => t.CreatedDate)
                              .ToList();

                gvTasks.DataSource = tasks;
                gvTasks.DataBind();
            }
        }

        protected void gvTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int taskId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteTask")
            {
                using (var db = new ApplicationDbContext())
                {
                    var task = db.Tasks.Find(taskId);
                    if (task != null && task.UserId == User.Identity.GetUserId())
                    {
                        db.Tasks.Remove(task);
                        db.SaveChanges();
                    }
                }
                BindTasks();
            }
            else if (e.CommandName == "EditTask")
            {
                Response.Redirect("~/EditTask.aspx?id=" + taskId);
            }
        }
            protected void gvTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Status badge
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                if (lblStatus != null)
                {
                    switch (lblStatus.Text)
                    {
                        case "To Do":
                            lblStatus.CssClass = "badge bg-secondary";
                            break;
                        case "In Progress":
                            lblStatus.CssClass = "badge bg-primary";
                            break;
                        case "Done":
                            lblStatus.CssClass = "badge bg-success";
                            break;
                    }
                }

                // Priority badge
                Label lblPriority = (Label)e.Row.FindControl("lblPriority");
                if (lblPriority != null)
                {
                    switch (lblPriority.Text)
                    {
                        case "Low":
                            lblPriority.CssClass = "badge bg-info";
                            break;
                        case "Medium":
                            lblPriority.CssClass = "badge bg-warning text-dark";
                            break;
                        case "High":
                            lblPriority.CssClass = "badge bg-danger";
                            break;
                    }
                }
            }
        }
    }
    }
