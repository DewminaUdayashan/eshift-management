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
        private Button currentButton;
        private readonly MaterialSkinManager materialSkinManager;

        public CustomerDashboard()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            panelMenu.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
            panelLogo.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;
            pictureBoxLogo.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;

            foreach (var button in panelMenu.Controls.OfType<Button>())
            {
                button.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
                button.ForeColor = Color.Gainsboro;
            }

            // Default to My Jobs view
            ActivateButton(buttonMyJobs);
            ShowPane(new CustomerJobsPane());
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
            ShowPane(new CustomerJobsPane());
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            MessageBox.Show("My Profile pane will be implemented here.");
        }
    }
}