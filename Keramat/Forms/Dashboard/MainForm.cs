using Entities.AppSettings;
using Services.AppLayer;
using Services.Ui;

namespace Keramat.Forms.Dashboard {
    public partial class MainForm : Form {
        private readonly SplashForm splashForm;
        private readonly IFontsService fontsService;
        private readonly IAppSettingsService appSettingsService;
        private readonly IAppVersionService appVersionService;

        public MainForm(
            SplashForm splashForm,
            IFontsService fontsService,
            IAppSettingsService appSettingsService,
            IAppVersionService appVersionService
            ) {

            InitializeComponent();
            this.splashForm = splashForm;
            this.fontsService = fontsService;
            this.appSettingsService = appSettingsService;
            this.appVersionService = appVersionService;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var result = splashForm.ShowDialog();
            //this.Font = fontsService.Get()?.DefaultFont;

            load();
            this.WindowState = FormWindowState.Maximized;
        }

        void load() {
            this.Text = "اپلیکیشن کرامت";
            lblTitle.Text = "اپلیکیشن کرامت";
            lblTitle.Font = fontsService.FontByRatio(1.4);
            lblFooter.Text = $"نسخه: {appVersionService.VersionString()}";
            lblFooter.Font = fontsService.FontByRatio(0.8);

            lblChrityName.Text = appSettingsService.Get(AppSettingsKeys.Charity_Name);
            lblChrityName.Font = fontsService.FontByRatio(2);
            lblCharitySlogan.Text = appSettingsService.Get(AppSettingsKeys.Charity_Slogan);
            lblCharitySlogan.Font = fontsService.FontByRatio(1.2);

            addSideButtons();
        }

        void addSideButtons() {
            sideBtnPnl.Controls.Clear();
            var btnList = new Dictionary<string, string>();
            btnList.Add("valiNematan", "ولی‌نعمتان");
            btnList.Add("khayyerin", "خیرین");
            btnList.Add("faaliat", "فعالیت");
            btnList.Add("gozaresh", "گزارش");
            btnList.Add("taqvim", "تقویم");
            btnList.Add("tanzimat", "تنظیمات");

            foreach (var item in btnList) {
                var ctl = new Button {
                    Padding = new Padding(8),
                    Margin = new Padding(0, 0, 0, 10),
                    Name = item.Key,
                    Text = item.Value,
                    Font = fontsService.Get()?.DefaultFont,
                    Size = new Size(200, 60)
                };
                sideBtnPnl.Controls.Add(ctl);

                ctl.Click += sideBtnClick;
            }

        }

        private void sideBtnClick(object? sender, EventArgs e) {
            var btn = sender as Button;

            switch (btn?.Name) {
                case "":
                    break;
                default:
                    break;
            }
        }
    }
}
