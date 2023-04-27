using Keramat.Utilities;

namespace Keramat.Forms.ValiNematan {
    public partial class FamilyForm : Form, ISavableForm {
        private bool _HasChanges { get; set; } = false;
        public bool HasChanges {
            get => _HasChanges;
            set {
                _HasChanges = value;
                btnSave.Enabled = value;
            }
        }

        public async Task SaveChanges() {
            if (HasChanges) {
                ///

                HasChanges = false;
            }
        }

        public async Task CloseAfterUserSubmit() {
            if (HasChanges) {
                if (true) {
                    SaveChanges();
                    this.Close();
                }
            }
            else {
                this.Close();
            }
        }

        public FamilyForm() {
            InitializeComponent();
        }

        public async Task LoadData(int id = 0) {
            if (id == 0) {
                this.Text = "افزودن خانواده";
            }
            else {
                this.Text = "خانواده {} [{id}]";
            }
        }

        private async void FamilyForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (HasChanges) { await CloseAfterUserSubmit(); }
        }

        private void btnSave_Click(object sender, EventArgs e) {

        }

        private void btnPrint_Click(object sender, EventArgs e) {

        }

        private void btnChanges_Click(object sender, EventArgs e) {
            //HasChanges = !HasChanges;
        }
    }
}
