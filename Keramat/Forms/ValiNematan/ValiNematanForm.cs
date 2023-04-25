using KeramatUIControls.GridView.Models;
using Mapster;
using Services.Ui;
using Services.ValiNematan;

namespace Keramat.Forms.ValiNematan {
    public partial class ValiNematanForm : Form {
        private readonly IFontsService fontsService;
        private readonly IGetFamiliesListService getFamiliesListService;

        public ValiNematanForm(
            IFontsService fontsService,
            IGetFamiliesListService getFamiliesListService
            ) {
            InitializeComponent();
            this.fontsService = fontsService;
            this.getFamiliesListService = getFamiliesListService;
            gridFooter.Font = fontsService.FontByRatio(1);
        }

        private string _searchTerm = "";
        public async Task Fetch(string search = "", int page = 1) {
            _searchTerm = search;
            await FetchPage(page);
        }
        public async Task FetchPage(int page) {
            var list = await getFamiliesListService.Search(_searchTerm, page);
            grid.DataSource = list.Items;
            gridFooter.Fill(list.Adapt<Pagination>());
        }

        private void ValiNematanForm_Load(object sender, EventArgs e) {
            Fetch();
        }

        private async Task gridFooter_PageChange(int page) {
            await FetchPage(page);
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e) {
            Fetch(txtSearch.Text, 1);
        }

        private void btnClearSearch_Click(object sender, EventArgs e) {
            txtSearch.Text = "";
            Fetch();
        }
    }
}
