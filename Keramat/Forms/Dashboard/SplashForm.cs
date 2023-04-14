using Keramat.Utilities;
using Services.Ui;

namespace Keramat.Forms.Dashboard {
    public partial class SplashForm : Form {
        private readonly IFontsService fontsService;

        public SplashForm(
            IFontsService fontsService
            ) {
            InitializeComponent();
            this.fontsService = fontsService;
        }

        private void SplashForm_Load(object sender, EventArgs e) {
            Task.WhenAll(Task.Delay(3000), fontsService.Load())
               .ContinueWith(x => this.PerformSafely(() => {
                   this.DialogResult = DialogResult.OK;
                   this.Close();
               }));
        }
    }
}
