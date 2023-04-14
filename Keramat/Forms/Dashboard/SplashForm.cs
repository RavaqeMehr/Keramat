using Keramat.Utilities;
using Services.AppLayer;
using Services.Ui;

namespace Keramat.Forms.Dashboard {
    public partial class SplashForm : Form {
        private readonly IFontsService fontsService;
        private readonly IAppSettingsService appSettingsService;

        public SplashForm(
            IFontsService fontsService,
            IAppSettingsService appSettingsService
            ) {
            InitializeComponent();
            this.fontsService = fontsService;
            this.appSettingsService = appSettingsService;
        }

        private void SplashForm_Load(object sender, EventArgs e) {
            Task.WhenAll(
                Task.Delay(3000),
                fontsService.Load()
                )
               .ContinueWith(x => this.PerformSafely(() => {
                   this.DialogResult = DialogResult.OK;
                   this.Close();
               }));
        }
    }
}
