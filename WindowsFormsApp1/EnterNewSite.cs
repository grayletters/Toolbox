using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManage
{
    public partial class EnterNewSite : Form
    {
        public string URL { get; set; }

        public EnterNewSite(int left, int top)
        {
            this.SetDesktopLocation(left, top);
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            URL = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
