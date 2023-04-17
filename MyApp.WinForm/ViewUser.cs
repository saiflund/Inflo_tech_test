using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using MyApp.Services.Factories.Interfaces;

namespace MyApp.WinForm
{
    public partial class ViewUser : Form
    {
        protected readonly int UserId;
        protected readonly Main Main;
        protected readonly IServiceFactory ServiceFactory;

        // This form relies upon the 'Main', the DataAccess, and the UserId in order to work
        public ViewUser(Main main, IServiceFactory serviceFactory, int userId)
        {
            UserId = userId;
            Main = main;
            ServiceFactory = serviceFactory;

            InitializeComponent();
        }

        // Load the user for the display
        private void ViewUser_Load(object sender, System.EventArgs e)
        {
            // Get the user by the ID
            var user = ServiceFactory.UserService.GetById(UserId);

            // If we have a user then show their details
            if (user != null)
            {
                lblForename.Text = user.Forename;
                lblSurname.Text = user.Surname;
                lblIsActive.Text = (user.IsActive ? "Yes" : "No");
                lblDOB.Text = user.DateOfBirth.ToString("D");

                listView1.Items.AddRange(user.DataLogs.Select(p => new ListViewItem
                (
                    new[]
                    {
                        p.LogAction.ToString(),
                        p.LogTime.ToString("f")
                    }
                )).ToArray());

            }
        }

        // A back button to go back to the main list view
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Override the closing event to show the Main form again
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Main.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
