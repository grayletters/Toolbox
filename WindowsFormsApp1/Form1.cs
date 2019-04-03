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

using System.Runtime.InteropServices; //mouse_event stuff

namespace WindowsFormsApp1
{
    public partial class PassForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private BindingList<Node> pass_data = new BindingList<Node>();
        private Search search_box = new Search();
        private Dictionary<string, List<ValueTuple<string, string>>> pass_data_all = new Dictionary<string, List<(string, string)>>();
        private Dictionary<string, string> site_map = new Dictionary<string, string>();
        private List<ValueTuple<string, string>> current_site = null;
        private int current_user = 0;
        private bool start_flag = true;

        //private Int16 shift_key = 1;

        public PassForm()
        {
            InitializeComponent();
            LoadData();

            //listpass settings
            listPass.DataSource = pass_data;
            listPass.DisplayMember = "site";
            listPass.ValueMember = "data";

            UpdateSiteList();
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
            Dictionary<string, bool> sites_loaded = new Dictionary<string, bool>();
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
                    string site_name = NodeUtils.get_site_name(site);
                    add_to_pass_data_all(site_name, user, password);
                    sites_loaded[site] = true;
                    site_map[site_name] = site;
                }
            }
            foreach (string site_in_file in sites_loaded.Keys)
            {
                search_box.Add(NodeUtils.get_site_name(site_in_file));
            }
        }
        
        private void UpdateSiteList()
        {
            while (pass_data.Count > 0) pass_data.RemoveAt(0);
            foreach (string site in pass_data_all.Keys)
            {
                foreach ((string user, string password) in pass_data_all[site])
                {
                    Node new_site = new Node() { site = NodeUtils.get_site_name(site), data = (site, user, password) };
                    pass_data.Add(new_site);
                    break; //only load the site name
                }
            }
        }

        // true - site exists, false - new site
        private bool add_to_pass_data_all(string site, string user, string password) 
        {
            bool res = true;
            if (!pass_data_all.ContainsKey(site))
            {
                pass_data_all.Add(site, new List<(string, string)>());
                res = false;
            }
            pass_data_all[site].Add((user, password));
            return res;
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
            string encrypted_user = NodeUtils.Encrypt(txtAddUser.Text, get_cipher_type(), shift_key);
            string encrypted_pass = NodeUtils.Encrypt(txtAddPass.Text, get_cipher_type(), shift_key);
            string site_name = NodeUtils.get_site_name(txtAddSite.Text);
            Node add_data = new Node() {
                site = site_name,
                data = (site_name, encrypted_user, encrypted_pass)
            };
            if (false == pass_data_all.ContainsKey(site_name))
            {
                search_box.Add(site_name);
                site_map[site_name] = txtAddSite.Text;
            }
            if (false == add_to_pass_data_all(site_name, encrypted_user, encrypted_pass)) pass_data.Add(add_data);
            txtAddUser.Text = "";
            txtAddPass.Text = "";
            txtAddSite.Text = "";
            txtAddSite.Focus();
        }

        private void listPass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //current_user = 0;
            if (true == start_flag) //dont do this on startup
            {
                return;
            }
            Node selected_site = (Node)listPass.SelectedItem;
            if (null != selected_site && true == CipherCheck())
            {
                current_user = 0;
                current_site = pass_data_all[selected_site.data.Item1];
                int site_users = current_site.Count;
                lblDataUsers.Text = "Users : " + site_users.ToString();

                if (site_users > 1)
                {
                    btnDataNextUser.Enabled = true;
                    btnDataPrevUser.Enabled = true;
                } else
                {
                    btnDataNextUser.Enabled = false;
                    btnDataPrevUser.Enabled = false;
                }
                Int16 shift_key = Convert.ToInt16(txtKey.Text);
                //List<(string, string)> user_list = pass_data_all[selected_site.data.Item1];
                (string user, string password) = current_site[current_user];
                txtDataUser.Text = NodeUtils.Decrypt(user, get_cipher_type(), shift_key);
                txtDataPass.Text = NodeUtils.Decrypt(password, get_cipher_type(), shift_key);
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
                pass_data_all.Remove(((Node)listPass.SelectedItem).data.Item1);

                listPass.SelectedItem = null;
                current_site = null;
                current_user = -1;

                update_user_data();
                UpdateSiteList();
                clear_selected_result();
            }
        }

        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int site_count = listPass.Items.Count;
            int i = 0;
            int amount_of_users = 0;
            foreach (string current_site in pass_data_all.Keys)
            {
                amount_of_users += pass_data_all[current_site].Count;
            }
            string[] lines = new string[3 * amount_of_users];
            foreach (string current_site in pass_data_all.Keys)
            { 
                foreach ((string, string) users in pass_data_all[current_site])
                {
                    lines[i] = site_map[current_site];
                    lines[i + 1] = users.Item1;
                    lines[i + 2] = users.Item2;
                    i += 3;
                }
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
            while (pass_data.Count > 0) pass_data.Remove(pass_data[0]);
            if ("" == textBox1.Text) UpdateSiteList();
            List<string> res = search_box.get_matches(textBox1.Text);
            if (null != res && res.Count > 0)
            {
                foreach (string s in res)
                {
                    Node new_site = new Node() { site = s, data = (s, "", "") };
                    pass_data.Add(new_site);

                    /*foreach ((string user, string password) in pass_data_all[s])
                    {
                        Node new_site = new Node() { site = s, data = (s, user, password) };
                        pass_data.Add(new_site);
                    }*/
                }
            }
            listPass.SelectedItem = null;
        }

        private void listPass_MouseDown_1(object sender, MouseEventArgs e)
        {
            listPass.SelectedIndex = listPass.IndexFromPoint(e.X, e.Y);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KeyEventArgs kea = new KeyEventArgs(Keys.Delete);
            listPass_KeyUp(sender, kea);
        }

        /*private void listpassMenuEdit_Click(object sender, EventArgs e)
        {
            if (null == listPass.SelectedItem) return;
            Node selected_site = (Node)listPass.SelectedItem;
            string a = selected_site.data.Item2;
            (string site, string user, string pass) = selected_site.data;
            Int16 shift_key = Convert.ToInt16(txtKey.Text);
            user = NodeUtils.Decrypt(user, get_cipher_type(), shift_key);
            pass = NodeUtils.Decrypt(pass, get_cipher_type(), shift_key);
            using (var edit_form = new PasswordsManage.EditWindow(pass_data_all[selected_site.site], txtKey.Text))
            {
                edit_form.Location = Cursor.Position;
                DialogResult dr = edit_form.ShowDialog();
                if (DialogResult.OK == dr)
                {
                    pass_data_all[selected_site.site] = edit_form.users;
                    update_user_data();
                }
            }
        }*/

        private void update_user_data()
        {
            if (current_user < 0)
            {
                lblDataUsers.Text = "Users :";
                txtDataUser.Text = "";
                txtDataPass.Text = "";
            } else
            {
                lblDataUsers.Text = "Users : " + current_site.Count.ToString();
                Int16 shift_key = Convert.ToInt16(txtKey.Text);
                (string user, string password) = current_site[current_user];
                txtDataUser.Text = NodeUtils.Decrypt(user, get_cipher_type(), shift_key);
                txtDataPass.Text = NodeUtils.Decrypt(password, get_cipher_type(), shift_key);
            }
        }

        private void btnDataNextUser_Click(object sender, EventArgs e)
        {
            current_user = (current_user + 1) % current_site.Count;
            update_user_data();
        }

        private void btnDataPrevUser_Click(object sender, EventArgs e)
        {
            current_user = (current_user > 0) ? (current_user - 1) % current_site.Count : current_site.Count - 1;
            update_user_data();
        }

        private void btnDataSave_Click(object sender, EventArgs e)
        {
            Int16 shift_key = Convert.ToInt16(txtKey.Text);
            string new_user = NodeUtils.Encrypt(txtDataUser.Text, "shift", shift_key);
            string new_pass = NodeUtils.Encrypt(txtDataPass.Text, "shift", shift_key);

            current_site[current_user] = (new_user, new_pass);
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            if (current_site.Count == 1)
            {
                pass_data_all.Remove(((Node)listPass.SelectedItem).site);
                txtDataUser.Text = "";
                txtDataPass.Text = "";
                current_user = -1;
                current_site = null;
                UpdateSiteList();                
            }
            else
            {
                Int16 shift_key = Convert.ToInt16(txtKey.Text);
                string new_user = NodeUtils.Encrypt(txtDataUser.Text, "shift", shift_key);
                string new_pass = NodeUtils.Encrypt(txtDataPass.Text, "shift", shift_key);

                current_site.Remove((new_user, new_pass));
                current_user = Math.Abs(current_user - 1) % current_site.Count;
            }
            update_user_data();
        }

        private void listPass_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://gmail.com");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label11.Text = NodeUtils.get_site_name(textBox2.Text);
        }

        private void listPass_DoubleClick(object sender, EventArgs e)
        {
            string site = ((Node)listPass.SelectedItem).data.Item1;
            string url = "";
            if (string.Compare(site, "Gmail", true) == 0)
            {
                url = @"https://mail.google.com/mail/u/?authuser=" + txtDataUser.Text;
            } else
            {
                url = site_map[site];
            }
            try
            {
                System.Diagnostics.Process.Start(url);
            } catch
            {
                using (var form = new PasswordsManage.EnterNewSite(Cursor.Position.X - 100, Cursor.Position.Y - 70))
                {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string newURL = form.URL;            //values preserved after close                    
                        site_map[site] = newURL;
                    }
                }
            }
        }

        /*large, small, count, symbol*/
        private (bool, bool, bool, bool, bool) analyse_password_strength(string password)
        {
            bool bLargeLetter = false;
            bool bSmallLetter = false;
            bool bLetterCount = false;
            bool bSymbol = false;
            bool bNumber = false;
            foreach (char c in password)
            {
                bool bIsAlphaNumeric = false;
                if (c >= 'A' && c <= 'Z') { bLargeLetter = true; bIsAlphaNumeric = true; }
                if (c >= 'a' && c <= 'z') { bSmallLetter = true; bIsAlphaNumeric = true; }
                if (c >= '0' && c <= '9') { bNumber = true; bIsAlphaNumeric = true; }
                if (!bIsAlphaNumeric) bSymbol = true;                
            }
            bLetterCount = (password.Length >= 8);
            return (bLargeLetter, bSmallLetter, bLetterCount, bSymbol, bNumber);
        }

        private void txtAddPass_TextChanged(object sender, EventArgs e)
        {
            (cbLargeLetter.Checked, cbSmallLetter.Checked, cbLetterCount.Checked, cbSymbol.Checked, cbNumber.Checked) = 
                analyse_password_strength(txtAddPass.Text);
        }
    }
}
