using MyApp.Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyApp.Services.Factories.Interfaces;
using MyApp.Models;
using System.Text.RegularExpressions;

namespace MyApp.WinForm
{
    public partial class UserInformation : Form
    {
        protected readonly int UserId;
        protected readonly Main Main;
        protected readonly IServiceFactory ServiceFactory;

        protected readonly User user;

        // This form relies upon the 'Main', the DataAccess, and the UserId in order to work
        public UserInformation(Main main, IServiceFactory serviceFactory, int userId)
        {
            UserId = userId;
            Main = main;
            ServiceFactory = serviceFactory;

            if (UserId == -1)
            {
                // If id is -1, a new User can be added. Creates a new empty User in which data can be added to.
                user = new User();
            }
            else
            {
                // Else, the selected User ID is passed through in order to get the user to allow for editing.
                user = ServiceFactory.UserService.GetById(UserId);
            }

            InitializeComponent();
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            ActiveTest.Checked = true;

            // If a user is found then show their detials
            if (UserId != -1)
            {
                txtFore.Text = user.Forename;
                txtSur.Text = user.Surname;
                ActiveTest.Checked = (user.IsActive ? true : false);
                dtpDateOfBirth.Value = user.DateOfBirth;
            }
        }

        // Validation on all input data
        // Only returns true if the date of birth is before current date
        private static bool ValidateDateOfBirth(DateTime date)
        {
            return DateTime.Now.Date > date.Date;
        }

        // Only returns true if the regex is matched
        private static bool ValidateName(String name)
        {
            return Regex.IsMatch(name, @"^[\w'\-,.][^0-9_!¡?÷?¿\/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            txtFore.Text = txtFore.Text.Trim();
            txtSur.Text = txtSur.Text.Trim();

            if (txtFore.Text == "" || txtSur.Text == "")
            {
                // Pop up tells user to check their input fields
                MessageBox.Show("Please fill in all fields", "Error, field empty");
                txtFore.Focus();
                txtSur.Focus();
                return;
            }

            if (!ValidateName(txtFore.Text))
            {
                // Pop up tells user to check their forename input
                MessageBox.Show("Forename must contain at least one character, these can include letters, comma, spaces, apostrophe, dot, dash. Includes support for most languages",
                    "Please check Forename");
                txtFore.Focus();
                return;
            }

            if (!ValidateName(txtSur.Text))
            {
                // Pop up tells user to check their surname input
                MessageBox.Show("Surname must contain at least one character, these can include letters, comma, spaces, apostrophe, dot, dash. Includes support for most languages",
                "Please check Surname");
                txtSur.Focus();
                return;
            }

            if (!ValidateDateOfBirth(dtpDateOfBirth.Value))
            {
                // Pop up tells user to check their date of birth input
                MessageBox.Show("The DoB must be earlier than the current date", "Please check Date of Birth");
                dtpDateOfBirth.Focus();
                return;
            }

            // Update user information
            user.Forename = txtFore.Text;
            user.Surname = txtSur.Text;
            user.IsActive = (ActiveTest.Checked == true); // true=checked false=unchecked
            user.DateOfBirth = dtpDateOfBirth.Value;

            var allUsers = ServiceFactory.UserService.GetAll().ToList();

            // Checks if user id exists
            // If user exists, adds 1 to the highest user id number 
            // This new number becomes the 'log' number to which edits are assigned a value
            if (UserId == -1)
            {
                var newUserId = allUsers.Max(user => user.Id) + 1;
                var highestDataLogId = allUsers.SelectMany(p => p.DataLogs).OrderByDescending(p => p.Id).FirstOrDefault()?.Id ?? 0;

                var dataLog = new DataLogger
                {
                    Id = highestDataLogId + 1,
                    UserId = newUserId,
                    LogTime = DateTime.Now,
                    LogAction = DataLogAction.Add
                };

                user.DataLogs = new List<DataLogger>();
                user.DataLogs.Add(dataLog);

                // Creates a new user if no user id is found
                ServiceFactory.UserService.Create(user);

            }
            else
            {
                var currentUser = ServiceFactory.UserService.GetById(UserId);

                var highestDataLogId = allUsers.SelectMany(p => p.DataLogs).OrderByDescending(p => p.Id).FirstOrDefault()?.Id ?? 0;

                var dataLog = new DataLogger
                {
                    Id = highestDataLogId + 1,
                    UserId = UserId,
                    LogTime = DateTime.Now,
                    LogAction = DataLogAction.Edit
                };

                user.DataLogs.Add(dataLog);

                // Updates an existing user so the update funtion is used
                ServiceFactory.UserService.Update(user);
            }

            this.Close();
        }

        // Closes this form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Return to the main form again using Override
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Main.Show();
        }
    }
}
