using Services.Ui;

namespace Keramat.Forms.Dashboard {
    public partial class MainForm : Form {
        private readonly SplashForm splashForm;
        private readonly IFontsService fontsService;

        public MainForm(
            SplashForm splashForm,
            IFontsService fontsService
            ) {

            InitializeComponent();
            this.splashForm = splashForm;
            this.fontsService = fontsService;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.Hide();
            var result = splashForm.ShowDialog();
            this.Font = fontsService.Get()?.DefaultFont;
            this.Show();
        }
    }
}
