using KeramatUIControls.Common;
using KeramatUIControls.GridView.Models;
using System.ComponentModel;
using System.Dynamic;
using DataColumn = KeramatUIControls.GridView.Models.DataColumn;

namespace KeramatUIControls.GridView {
    public partial class GridView : UserControl, ISupportInitialize {

        #region Properties

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Columns List"), Category(StaticFields.PropertyCategory)]
        public List<DataColumn> Columns {
            get { return _Columns; }
            set { // update header & panel
                _Columns = value;
                Header.Columns = value;
            }
        }
        private List<DataColumn> _Columns = new();

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Pagination"), Category(StaticFields.PropertyCategory)]
        public Pagination? Pagination {
            get { return _Pagination; }
            set { _Pagination = value; } // update footer
        }
        private Pagination? _Pagination;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Data List"), Category(StaticFields.PropertyCategory)]
        public List<DynamicObject>? Data {
            get { return _Data; }
            set { _Data = value; } // update panel
        }
        private List<DynamicObject>? _Data;

        #endregion

        #region Public Methods
        public void Fill(WithPagination withPagination) {
            this.Data = withPagination.Items;
            this.Pagination = new Pagination {
                TotalItems = withPagination.TotalItems,
                ItemsPerPage = withPagination.ItemsPerPage,
                TotalPages = withPagination.TotalPages,
                CurrentPage = withPagination.CurrentPage
            };
        }

        #endregion
        public void BeginInit() {
            throw new NotImplementedException();
        }

        public void EndInit() {
            throw new NotImplementedException();
        }


        public GridView() {
            InitializeComponent();
        }
    }
}
