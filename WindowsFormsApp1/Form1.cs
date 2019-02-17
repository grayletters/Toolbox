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
        private bool start_flag = true;
        private Search search_box;
        private Dictionary<string, List<ValueTuple<string, string>>> pass_data_all = new Dictionary<string, List<(string, string)>>();
        //private Int16 shift_key = 1;

        public PassForm()
        {
            InitializeComponent();

            //listpass settings
            listPass.DataSource = pass_data;
            listPass.ValueMember = "data";
            listPass.DisplayMember = "site";
            search_box = new Search();
      
            LoadData();
            ShowData();
            start_flag = false;
        }

        private void clear_selected_result()
        {
            txtDataUser.Text = "";
            txtDataPass.Text = "";
        }

        private bool CipherCheck()
        {
            if (txtKey.Text == "")
            {
                MessageBox.Show("Please fill in a cipher number down below", "Number Cipher Error");
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            //load site file into pass_data
            int i = 0;
            string site = "";
            string user = "";
            string password = "";
            string filename = "Passlist";
            string full_path = Environment.CurrentDirectory + "\\" + filename;
            if (false == File.Exists(full_path)) File.Create(full_path);
            foreach (string line in File.ReadLines(full_path, Encoding.UTF8))
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
                    add_to_pass_data_all(site, user, password);
                    search_box.Add(site);
                }
            }
        }

        private void ShowData()
        {
            foreach (string site in pass_data_all.Keys)
            {
                foreach ((string user, string password) in pass_data_all[site])
                {
                    Node new_site = new Node() { site = site, data = (site, user, password) };
                    pass_data.Add(new_site);
                }
            }
        }

        private void add_to_pass_data_all(string site, string user, string password)
        {
            if (!pass_data_all.ContainsKey(site)) pass_data_all.Add(site, new List<(string, string)>());
            pass_data_all[site].Add((user, password));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAddSite.Text == "" || txtAddUser.Text == "" || txtAddPass.Text == "")
            {
                MessageBox.Show("Please make sure the fields are all filled!", "Data Error");
                return;
            }
            if (false == CipherCheck()) return;
            Int16 shift_key = Convert.ToInt16(txtKey.Text);
            string encrypted_pass = NodeUtils.Encrypt(txtAddPass.Text, get_cipher_type(), shift_key);     
            Node add_data = new Node() {
                site = txtAddSite.Text,
                data = (txtAddSite.Text, txtAddUser.Text, encrypted_pass)
            };
            search_box.Add(txtAddSite.Text);
            pass_data.Add(add_data);
            add_to_pass_data_all(txtAddSite.Text, txtAddUser.Text, encrypted_pass);
            txtAddUser.Text = "";
            txtAddPass.Text = "";
            txtAddSite.Text = "";
            txtAddSite.Focus();
        }

        private void listPass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (true == start_flag) //dont do this on startup
            {
                return;
            }
            Node selected_site = (Node)listPass.SelectedItem;
            if (null != selected_site && true == CipherCheck())
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

        private void listPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                pass_data.Remove((Node)listPass.SelectedItem);
                clear_selected_result();
            }
        }

        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int site_count = listPass.Items.Count;
            string[] lines = new string[3 * site_count];
            for (int i = 0; i < 3 * site_count; i += 3)
            {
                Node site = (Node)listPass.Items[(int)(i / 3)];
                lines[i] = site.data.Item1;
                lines[i + 1] = site.data.Item2;
                lines[i + 2] = site.data.Item3;
            }
            System.IO.File.WriteAllLines(Environment.CurrentDirectory + @"\PassList", lines);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyEventArgs kea = new KeyEventArgs(Keys.Delete);
            listPass_KeyUp(sender, kea);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            clear_selected_result();
            while (pass_data.Count > 0)
            {
                pass_data.Remove(pass_data[0]);
            }
            if ("" == textBox1.Text) ShowData();
            List<string> res = search_box.get_matches(textBox1.Text);
            if (null != res && res.Count > 0)
            {
                foreach (string s in res)
                {
                    foreach ((string user, string password) in pass_data_all[s])
                    {
                        Node new_site = new Node() { site = s, data = (s, user, password) };
                        pass_data.Add(new_site);
                    }
                }
            }
        }

        private void listPass_MouseEnter(object sender, EventArgs e)
        {
            listPass.SelectionMode = SelectionMode.One;
        }

        private void listPass_MouseLeave(object sender, EventArgs e)
        {
            listPass.SelectionMode = SelectionMode.None;
        }
    }
}
