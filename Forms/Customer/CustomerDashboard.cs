using eshift_management.Models;
using eshift_management.Panes;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class CustomerDashboard : MaterialForm
    {
        private UserModel user;
        private Button? currentButton;
        private readonly MaterialSkinManager materialSkinManager;

        public CustomerDashboard(UserModel user)
        {
            InitializeComponent();
            this.user = user;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo700,     // Blue sidebar/header/buttons
                Primary.Indigo800,     // Darker version
                Primary.Indigo500,     // Lighter tone
                Accent.Blue200,        // Subtle accent
                TextShade.WHITE        // White text on dark areas
            );

            panelMenu.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
            panelLogo.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;
            pictureBoxLogo.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;

            foreach (var button in panelMenu.Controls.OfType<Button>())
            {
                button.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
                button.ForeColor = Color.Gainsboro;
            }

            ActivateButton(buttonMyJobs);
            ShowPane(new CustomerJobsPane(user));
        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                if (currentButton != (Button)senderBtn)
                {
                    DisableButton();
                    currentButton = (Button)senderBtn;
                    currentButton.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        private void ShowPane(UserControl pane)
        {
            panelMain.Controls.Clear();
            pane.Dock = DockStyle.Fill;
            panelMain.Controls.Add(pane);
            pane.Show();
        }

        private void buttonMyJobs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new CustomerJobsPane(user));
        }

        private void buttonPlaceJob_Click(object sender, EventArgs e)
        {
            // This button is now on the CustomerJobsPane
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new CustomerProfilePane(user));
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.ShowDialog(); // Block until login form is closed
                this.Close();
            }
        }
    }
}