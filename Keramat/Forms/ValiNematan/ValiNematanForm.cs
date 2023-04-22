using Services.ValiNematan;

namespace Keramat.Forms.ValiNematan {
    public partial class ValiNematanForm : Form {
        private readonly IGetFamiliesListService getFamiliesListService;

        public ValiNematanForm(
            IGetFamiliesListService getFamiliesListService
            ) {
            InitializeComponent();
            this.getFamiliesListService = getFamiliesListService;
        }

        public async Task Load() {
            var list = await getFamiliesListService.Search();
            grid.DataContext = list;
        }
    }
}
