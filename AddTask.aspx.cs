using System;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using TaskManager.Models;

namespace TaskManager
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var task = new TaskItem
                    {
                        Title = txtTitle.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        Status = ddlStatus.SelectedValue,
                        Priority = ddlPriority.SelectedValue,
                        UserId = User.Identity.GetUserId(),
                        CreatedDate = DateTime.Now
                    };

                    if (!string.IsNullOrEmpty(txtDueDate.Text))
                    {
                        task.DueDate = DateTime.Parse(txtDueDate.Text);
                    }

                    db.Tasks.Add(task);
                    db.SaveChanges();
                }

                Response.Redirect("~/Tasks.aspx");
            }
        }
    }
}