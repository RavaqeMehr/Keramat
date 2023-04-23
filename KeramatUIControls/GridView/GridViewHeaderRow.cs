using KeramatUIControls.Common;
using System.ComponentModel;
using DataColumn = KeramatUIControls.GridView.Models.DataColumn;

namespace KeramatUIControls.GridView {
    public partial class GridViewHeaderRow : UserControl {

        #region Properties

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Columns List"), Category(StaticFields.PropertyCategory)]
        public List<DataColumn> Columns {
            get { return _Columns; }
            set { // update cols
                _Columns = value;
                LoadColumns();
            }
        }
        private List<DataColumn> _Columns = new();

        #endregion

        private void LoadColumns() {
            var cols = Columns.Where(x => x.Visible);
            if (cols.Count() > 0) {
                var totalWidth = cols.Sum(x => x.Width);
                var widthUnit = this.Width / totalWidth;
                this.Controls.Clear();
                foreach (var col in cols) {
                    var lbl = new Label {
                        AutoSize = false,
                        Size = new Size(col.Width * widthUnit, this.Height),
                        Dock = DockStyle.Right,
                        Text = col.Title
                    };
                    this.Controls.Add(lbl);
                }
            }

        }

        public GridViewHeaderRow() {
            InitializeComponent();
        }

        private void GridViewHeaderRow_SizeChanged(object sender, EventArgs e) {
            LoadColumns();
        }
    }
}
