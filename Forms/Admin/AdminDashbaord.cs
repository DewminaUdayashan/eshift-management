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
        // Fields to track the currently active button and panel
        private Button currentButton;
        private readonly MaterialSkinManager materialSkinManager;

        public AdminDashboard()
        {
            InitializeComponent();

            // Initialize and apply the MaterialSkin theme and colors
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // Apply theme colors to custom panels to match the title bar
            panelMenu.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
            panelLogo.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;

            // Set the initial background and foreground color for all menu buttons
            foreach (var button in panelMenu.Controls.OfType<Button>())
            {
                button.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
                button.ForeColor = Color.Gainsboro;
            }

            // Activate the default button, which will override its color for the highlight
            ActivateButton(buttonDashboard);
            ShowPane(new DashboardPane());
        }

        /// <summary>
        /// Highlights the clicked button and de-highlights the previous one.
        /// </summary>
        /// <param name="senderBtn">The button that was clicked.</param>
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                if (currentButton != (Button)senderBtn)
                {
                    DisableButton();

                    // Set the new active button and apply the theme highlight
                    currentButton = (Button)senderBtn;
                    currentButton.BackColor = materialSkinManager.ColorScheme.DarkPrimaryColor;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }

        /// <summary>
        /// Resets the style of the previously active button.
        /// </summary>
        private void DisableButton()
        {
            if (currentButton != null)
            {
                // Set button color back to the main menu color
                currentButton.BackColor = materialSkinManager.ColorScheme.PrimaryColor;
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        /// <summary>
        /// Displays a UserControl in the main panel.
        /// </summary>
        /// <param name="pane">The UserControl to display.</param>
        private void ShowPane(UserControl pane)
        {
            // Clear previous controls and display the new one
            panelMain.Controls.Clear();
            pane.Dock = DockStyle.Fill;
            panelMain.Controls.Add(pane);
            pane.Show();
        }

        // --- Menu Button Click Events ---

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new DashboardPane());
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // TODO: Create and show Customers pane
        }

        private void buttonResources_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // TODO: Create and show Resources pane
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