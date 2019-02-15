using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PassForm : Form
    {
        private BindingList<Node> pass_data = new BindingList<Node>();
        //private Int16 shift_key = 1;

        public PassForm()
        {
            InitializeComponent();
            ShowData();
        }

        private void ShowData()
        {
            //listpass settings
            listPass.DataSource = pass_data;
            listPass.ValueMember = "data";
            listPass.DisplayMember = "site";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Int16 shift_key = Convert.ToInt16(txtKey.Text);

            Node add_data = new Node() {
                site = txtAddWhere.Text,
                data = (txtAddWhere.Text, txtAddUser.Text, NodeUtils.Encrypt(txtAddPass.Text, get_cipher_type(), shift_key))
            };
            txtAddWhere.Text = "";
            txtAddUser.Text = "";
            txtAddPass.Text = "";
            pass_data.Add(add_data);
            txtAddWhere.Focus();
        }

        private void listPass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Node selected_site = (Node)listPass.SelectedItem;
            if (null != selected_site)
            {
                txtDataUser.Text = selected_site.data.Item2;
                Int16 shift_key = Convert.ToInt16(txtKey.Text);
                txtDataPass.Text = NodeUtils.Decrypt(selected_site.data.Item3, get_cipher_type(), shift_key);
            }
        }

        private string get_cipher_type()
        {
            string cipher_text = "", res = "";
            foreach (RadioButton rb in grpCiphers.Controls)
            {
                if (rb.Checked)
                {
                    cipher_text = rb.Name;
                }
            }

            switch (cipher_text)
            {
                case "rbCipherShift":
                    res = "shift";
                    break;
            }
            return res;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int site_count = listPass.Items.Count;
            string[] lines = new string[3*site_count];
            for (int i = 0; i < 3*site_count; i += 3)
            {
                Node site = (Node)listPass.Items[(int)(i/3)];
                lines[i] = site.data.Item1;
                lines[i + 1] = site.data.Item2;
                lines[i + 2] = site.data.Item3;
            }
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            System.IO.File.WriteAllLines(Environment.CurrentDirectory + @"\PassList", lines);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //remove all sites from the list
            while (pass_data.Count > 0)
            {
                pass_data.Remove(pass_data[0]);
            }

            //import the data
            int i = 0;
            string site = "";
            string user = "";
            string password = "";
            string filename = "Passlist";
            foreach (string line in File.ReadLines(Environment.CurrentDirectory + "\\" + filename, Encoding.UTF8))
            {
                // process 
                int loc = i++ % 3;
                switch (loc)
                {
                    case 0:
                        site = line;
                        break;
                    case 1:
                        user = line;
                        break;
                    case 2:
                        password = line;
                        break;
                }
                if (i % 3 == 0)
                {
                    //Int16 shift_key = Convert.ToInt16(txtKey.Text);
                    Node new_site = new Node() { site = site, data = (site, user, password) };
                    pass_data.Add(new_site);
                }
            }
        }

        private void listPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                pass_data.Remove((Node)listPass.SelectedItem);
            }
        }
    }
}
