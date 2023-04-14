using Keramat.Utilities;
using Services.Ui;

namespace Keramat.Forms.Dashboard {
    public partial class MainForm : Form {
        private readonly IFontsService fontsService;

        public MainForm(
            IFontsService fontsService
            ) {
            InitializeComponent();
            this.fontsService = fontsService;

            fontsService.Get().ContinueWith(x => this.PerformSafely(() => {
                this.Font = x.Result.DefaultFont;
            }));

        }
    }
}
