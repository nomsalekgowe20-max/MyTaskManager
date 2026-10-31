using System;
using System.Linq;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using TaskManager.Models;

namespace TaskManager
{
    public partial class EditTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/Tasks.aspx");
                    return;
                }

                int taskId = Convert.ToInt32(Request.QueryString["id"]);
                LoadTask(taskId);
            }
        }

        private void LoadTask(int taskId)
        {
            string currentUserId = User.Identity.GetUserId();   // ← Get it first

            using (var db = new ApplicationDbContext())
            {
                var task = db.Tasks.FirstOrDefault(t => t.Id == taskId && t.UserId == currentUserId);

                if (task == null)
                {
                    Response.Redirect("~/Tasks.aspx");
                    return;
                }

                hfTaskId.Value = task.Id.ToString();
                txtTitle.Text = task.Title;
                txtDescription.Text = task.Description;
                ddlStatus.SelectedValue = task.Status;
                ddlPriority.SelectedValue = task.Priority;

                if (task.DueDate.HasValue)
                {
                    txtDueDate.Text = task.DueDate.Value.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int taskId = Convert.ToInt32(hfTaskId.Value);
                string currentUserId = User.Identity.GetUserId();   // ← Get it first

                using (var db = new ApplicationDbContext())
                {
                    var task = db.Tasks.FirstOrDefault(t => t.Id == taskId && t.UserId == currentUserId);

                    if (task != null)
                    {
                        task.Title = txtTitle.Text.Trim();
                        task.Description = txtDescription.Text.Trim();
                        task.Status = ddlStatus.SelectedValue;
                        task.Priority = ddlPriority.SelectedValue;

                        if (!string.IsNullOrEmpty(txtDueDate.Text))
                        {
                            task.DueDate = DateTime.Parse(txtDueDate.Text);
                        }
                        else
                        {
                            task.DueDate = null;
                        }

                        db.SaveChanges();
                    }
                }

                Response.Redirect("~/Tasks.aspx");
            }
        }
    }
}