using CustomDropDown;
using System;

namespace DropDownButton {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            this.comboBoxEdit1.Properties.Items.AddRange(Enum.GetValues(typeof(DevExpress.XtraEditors.DropDownArrowStyle)));
            this.comboBoxEdit1.SelectedIndex = 0;
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            this.customDropDownButton1.ArrowAlignment = this.customDropDownButton1.ArrowAlignment == ArrowAlignment.Right ? ArrowAlignment.Left : ArrowAlignment.Right;
            this.customDropDownButton1.Refresh();
        }
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e) {
            this.customDropDownButton1.DropDownArrowStyle = (DevExpress.XtraEditors.DropDownArrowStyle)this.comboBoxEdit1.SelectedItem;
            this.customDropDownButton1.Refresh();
        }
    }
}
