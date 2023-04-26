using Common.Utilities;
using KeramatUIControls.Common;
using System.ComponentModel;

namespace KeramatUIControls.Inputs {
    public partial class InputText : UserControl {
        public delegate Task TextChangeHandler(string text);
        [Browsable(true)]
        [Category(StaticFields.PropertyCategory)]
        [Description("Change Text of TextBox Event")]
        public event TextChangeHandler? TextChange;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text of TextBox"), Category(StaticFields.PropertyCategory)]
        public string Text {
            get { return _Text; }
            set {
                _Text = value;
                textBox.Text = value;
            }
        }
        private string _Text = "";

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Max Text Length of TextBox"), Category(StaticFields.PropertyCategory)]
        public int MaxLength {
            get { return _MaxLength; }
            set {
                _MaxLength = value;
                textBox.MaxLength = value;
            }
        }
        private int _MaxLength = 1000;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("ReadOnly status of TextBox"), Category(StaticFields.PropertyCategory)]
        public bool ReadOnly {
            get { return _ReadOnly; }
            set {
                _ReadOnly = value;
                textBox.ReadOnly = value;
            }
        }
        private bool _ReadOnly = false;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Title of TextBox"), Category(StaticFields.PropertyCategory)]
        public string Title {
            get { return _Title; }
            set {
                _Title = value;
                lblTitle.Text = value;
            }
        }
        private string _Title = "";

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Hint of TextBox"), Category(StaticFields.PropertyCategory)]
        public string Hint {
            get { return _Hint; }
            set {
                _Hint = value;
                lblHint.Text = value;
            }
        }
        private string _Hint = "";

        public void SetValidation(string text, InputColors color = InputColors.Normal) {
            lblValidation.ForeColor = color.ToColor();
            lblValidation.Text = text;
        }
        public void ClearValidation() {
            lblValidation.ForeColor = InputColors.Normal.ToColor();
            lblValidation.Text = "";
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Font of Elements"), Category(StaticFields.PropertyCategory)]
        public Font Font {
            get { return _Font; }
            set {
                _Font = value;
                lblTitle.Font = value.ByRatio(1.2);
                lblHint.Font = value.ByRatio(0.8);
                textBox.Font = value;
                lblValidation.Font = value.ByRatio(0.9);
                ResizeControl();
            }
        }
        private Font _Font = Form.DefaultFont;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Input mode of TextBox"), Category(StaticFields.PropertyCategory)]
        public InputMode Mode {
            get { return _Mode; }
            set {
                _Mode = value;
            }
        }
        private InputMode _Mode = InputMode.Normal;

        private void ResizeControl() {
            pnlTop.Height = textBox.Height;
            this.Height = textBox.Height * 3;
        }

        public InputText() {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e) {
            if (Mode == InputMode.integer) {
                _Text = textBox.Text.getNumbers();
            }
            else if (Mode == InputMode.number) {
                if (float.TryParse(textBox.Text, out float value)) {
                    _Text = value.ToString();
                }
                else {
                    _Text = textBox.Text.getNumbers();
                }
            }
            else {
                _Text = textBox.Text;
            }

            TextChange?.Invoke(textBox.Text);
        }

        private void InputText_Resize(object sender, EventArgs e) {
            ResizeControl();
        }

        private void InputText_Click(object sender, EventArgs e) {
            textBox.Focus();
        }

        private void InputText_DoubleClick(object sender, EventArgs e) {
            textBox.Focus();
            textBox.SelectAll();
        }

        private void textBox_Resize(object sender, EventArgs e) {
            ResizeControl();
        }
    }
}
