using Common.Utilities;
using KeramatUIControls.Common;
using KeramatUIControls.GridView.Models;
using System.ComponentModel;

namespace KeramatUIControls.GridView {
    public partial class GridViewFooter : UserControl {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Pagination"), Category(StaticFields.PropertyCategory)]
        public Pagination? Pagination {
            get { return _Pagination; }
            set { _Pagination = value; }
        }
        private Pagination? _Pagination;

        public delegate Task PageChangeHandler(int page);
        [Browsable(true)]
        [Category(StaticFields.PropertyCategory)]
        [Description("Invoked when user change page")]
        public event PageChangeHandler? PageChange;


        public GridViewFooter(
            ) {
            InitializeComponent();
        }

        private void GridViewFooter_Load(object sender, EventArgs e) {
            MakeUi();
        }

        public void Fill(Pagination pagination) {
            this.Pagination = pagination;

            MakeUi();
        }

        public void MakeUi() {
            if (this.Pagination is null) {
                this.Visible = false;
            }
            else {
                this.Controls.Clear();
                this.Visible = true;

                if (this.Pagination.TotalItems == 0) {
                    var ctl = new Label {
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        RightToLeft = RightToLeft.Yes,
                        Font = this.Font.ByRatio(1.2),
                        Text = "موردی جهت نمایش وجود ندارد!"
                    };

                    this.Controls.Add(ctl);
                }
                else {
                    var ctls = new List<Control>();

                    var pnl = new FlowLayoutPanel {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.RightToLeft,

                        //Height = this.ClientSize.Height,
                        Padding = new Padding(5),
                        Margin = new Padding(0, 0, 0, 0),
                        AutoSize = false,
                        Size = new Size(330, this.ClientSize.Height)
                    };

                    pnl.Controls.AddRange(new Control[] {
                        new Button {
                            Anchor=AnchorStyles.None,
                            UseVisualStyleBackColor=false,
                            FlatStyle=FlatStyle.Flat,
                            Size=new Size(50,this.ClientSize.Height -20),
                            TextAlign=ContentAlignment.MiddleCenter,
                            RightToLeft=RightToLeft.Yes,
                            Font = this.Font.ByRatio(0.8),
                            //Text=this.Pagination.CurrentPage==1? "<<":"1",
                            Text="<<",
                            //Enabled=this.Pagination.CurrentPage>1
                        },
                        new Button {
                            Anchor=AnchorStyles.None,
                            UseVisualStyleBackColor=false,
                            FlatStyle=FlatStyle.Flat,
                            Size=new Size(50,this.ClientSize.Height -20),
                            TextAlign=ContentAlignment.MiddleCenter,
                            RightToLeft=RightToLeft.Yes,
                            Font = this.Font.ByRatio(0.8),
                            //Text=this.Pagination.CurrentPage==1? "<":(this.Pagination.CurrentPage-1).ToNumeric(),
                            Text="<",
                            //Enabled=this.Pagination.CurrentPage>1
                        },
                        new Button {
                            Anchor=AnchorStyles.None,
                            UseVisualStyleBackColor=false,
                            FlatStyle=FlatStyle.Flat,
                            Size=new Size(70,this.ClientSize.Height -10),
                            TextAlign=ContentAlignment.MiddleCenter,
                            RightToLeft=RightToLeft.Yes,
                            Font = this.Font.ByRatio(1),
                            Text=this.Pagination.CurrentPage.ToNumeric(),
                            //Enabled=false
                        },
                        new Button {
                            Anchor=AnchorStyles.None,
                            UseVisualStyleBackColor=false,
                            FlatStyle=FlatStyle.Flat,
                            Size=new Size(50,this.ClientSize.Height -20),
                            TextAlign=ContentAlignment.MiddleCenter,
                            RightToLeft=RightToLeft.Yes,
                            Font = this.Font.ByRatio(0.8),
                            //Text=this.Pagination.CurrentPage>=this.Pagination.TotalPages? ">":(this.Pagination.CurrentPage+1).ToNumeric(),
                            Text= ">",
                            //Enabled=this.Pagination.CurrentPage<this.Pagination.TotalPages
                        },
                        new Button {
                            Anchor=AnchorStyles.None,
                            UseVisualStyleBackColor=false,
                            FlatStyle=FlatStyle.Flat,
                            Size=new Size(50,this.ClientSize.Height -20),
                            TextAlign=ContentAlignment.MiddleCenter,
                            RightToLeft=RightToLeft.Yes,
                            Font = this.Font.ByRatio(0.8),
                            //Text=this.Pagination.CurrentPage==this.Pagination.TotalPages? ">>":this.Pagination.TotalPages.ToNumeric(),
                            Text=">>",
                            //Enabled=this.Pagination.CurrentPage<this.Pagination.TotalPages
                        }
                    });
                    foreach (Control item in pnl.Controls) {
                        item.Click += pageClick;
                    }
                    ctls.Add(pnl);
                    ctls.Add(new Label {
                        //BorderStyle = BorderStyle.FixedSingle,
                        AutoSize = true,
                        Dock = DockStyle.Right,
                        Width = 150,
                        TextAlign = ContentAlignment.MiddleLeft,
                        RightToLeft = RightToLeft.Yes,
                        Font = this.Font.ByRatio(0.8),
                        Padding = new Padding(10),
                        Text = $"موارد {(((this.Pagination.CurrentPage - 1) * this.Pagination.ItemsPerPage) + 1).ToNumeric()} تا {Math.Min(this.Pagination.CurrentPage * this.Pagination.ItemsPerPage, this.Pagination.TotalItems).ToNumeric()} از {this.Pagination.TotalItems.ToNumeric()}"
                    });

                    ctls.Add(new Label {
                        //BorderStyle = BorderStyle.FixedSingle,
                        AutoSize = true,
                        Dock = DockStyle.Left,
                        Width = 150,
                        TextAlign = ContentAlignment.MiddleRight,
                        RightToLeft = RightToLeft.Yes,
                        Font = this.Font.ByRatio(0.8),
                        Padding = new Padding(10),
                        Text = $"صفحه {this.Pagination.CurrentPage.ToNumeric()} از {this.Pagination.TotalPages.ToNumeric()}"
                    });


                    this.Controls.AddRange(ctls.ToArray());


                    GridViewFooter_Resize(null, null);
                }
            }
        }

        private void pageClick(object? sender, EventArgs e) {
            var btn = (Button?)sender;
            if (btn != null && this.Pagination != null) {
                int page = this.Pagination.CurrentPage;
                switch (btn.Text) {
                    case "<<":
                        page = 1;
                        break;
                    case "<":
                        page = Math.Max(this.Pagination.CurrentPage - 1, 1);
                        break;
                    case ">":
                        page = Math.Min(this.Pagination.CurrentPage + 1, this.Pagination.TotalPages);
                        break;
                    case ">>":
                        page = this.Pagination.TotalPages;
                        break;
                    default:
                        break;
                }

                if (page != this.Pagination.CurrentPage) {
                    PageChange?.Invoke(page);
                }
            }
            //if (int.TryParse(btn?.Text, out int page)) {
            //    PageChange?.Invoke(page);
            //}
        }

        private void GridViewFooter_Resize(object? sender, EventArgs? e) {
            Panel? pnl = this.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
            if (pnl is not null) {
                var w = this.ClientSize.Width;
                //var pW = pnl.ClientSize.Width;
                var cW = pnl.Controls.OfType<Control>().Sum(x => x.Width + x.Margin.Left + x.Margin.Right);
                var l = this.Controls.OfType<Label>().FirstOrDefault();
                var lW = l.Width + l.Margin.Left + l.Margin.Right;
                pnl.Padding = new Padding(0, 5, ((w - cW) / 2) - lW, 0);
            }
        }
    }
}
