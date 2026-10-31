using System;
using System.Linq;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using TaskManager.Models;

namespace TaskManager
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                pnlDashboard.Visible = true;
                pnlWelcome.Visible = false;
                LoadDashboard();
            }
            else
            {
                pnlDashboard.Visible = false;
                pnlWelcome.Visible = true;
            }
        }

        private void LoadDashboard()
        {
            string userId = User.Identity.GetUserId();

            using (var db = new ApplicationDbContext())
            {
                var tasks = db.Tasks.Where(t => t.UserId == userId).ToList();

                lblTotal.Text = tasks.Count.ToString();
                lblToDo.Text = tasks.Count(t => t.Status == "To Do").ToString();
                lblInProgress.Text = tasks.Count(t => t.Status == "In Progress").ToString();
                lblDone.Text = tasks.Count(t => t.Status == "Done").ToString();
            }
        }
    }
}