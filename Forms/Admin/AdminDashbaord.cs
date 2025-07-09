using eshift_management.Panes;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class AdminDashboard : MaterialForm
    {
        private Button currentButton;
        private readonly MaterialSkinManager materialSkinManager;

        public AdminDashboard()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            panelMenu.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
            panelLogo.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;

            foreach (var button in panelMenu.Controls.OfType<Button>())
            {
                button.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
                button.ForeColor = Color.Gainsboro;
            }

            ActivateButton(buttonDashboard);
            ShowPane(new DashboardPane());
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

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new DashboardPane());
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new CustomersPane());
        }

        private void buttonTrucks_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new TrucksPane());
        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void buttonUnits_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // TODO: Create and show Transport Units pane
        }

        private void buttonJobs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // TODO: Create and show Jobs pane
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // TODO: Create and show Reports pane
        }
    }
}