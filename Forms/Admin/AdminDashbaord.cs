using eshift_management.Panes;
using MaterialSkin;
using MaterialSkin.Controls;

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
            ShowPane(new EmployeesPane());
        }

        private void buttonUnits_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new TransportUnitsPane());
        }

        private void buttonJobs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new JobsPane());
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPane(new ReportsPane());
        }
    }
}