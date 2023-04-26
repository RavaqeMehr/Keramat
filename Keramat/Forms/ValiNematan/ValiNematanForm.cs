using Keramat.Utilities;
using KeramatUIControls.GridView.Models;
using Mapster;
using Services.Ui;
using Services.ValiNematan;

namespace Keramat.Forms.ValiNematan {
    public partial class ValiNematanForm : Form {
        private readonly IFontsService fontsService;
        private readonly IGetFamiliesListService getFamiliesListService;
        private readonly IFormManager formManager;

        public ValiNematanForm(
            IFontsService fontsService,
            IGetFamiliesListService getFamiliesListService,
            IFormManager formManager
            ) {
            InitializeComponent();
            this.fontsService = fontsService;
            this.getFamiliesListService = getFamiliesListService;
            this.formManager = formManager;
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

        private async void ValiNematanForm_Load(object sender, EventArgs e) {
            await Fetch();
        }

        private async Task gridFooter_PageChange(int page) {
            await FetchPage(page);
        }

        private async void btnSearch_ButtonClick(object sender, EventArgs e) {
            await Fetch(txtSearch.Text, 1);
        }

        private async void btnClearSearch_Click(object sender, EventArgs e) {
            txtSearch.Text = "";
            await Fetch();
        }

        private async void btnAdd_ClickAsync(object sender, EventArgs e) {
            var frm = formManager.Create<FamilyForm>();
            await frm.LoadData();
            frm.Show();
        }
    }
}
