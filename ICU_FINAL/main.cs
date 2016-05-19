using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace ICU_FINAL
{
    public partial class main : MaterialForm
    {
        public static string SelectedHDD;
        public static string des_path;
        public main()
        {
            InitializeComponent();
            List<string> allDrives = DriveAccess.GetAllDrives(null);
            foreach (string s in allDrives) HDDcomboBox.Items.Add(s);
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void btnFormats_Click(object sender, EventArgs e)
        {
            fileformats form = new fileformats();
            form.Show();
        }

        private bool IsValidPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                return false;

            DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(path));
            if (!dir.Exists)
                dir.Create();
            return true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text != "" && HDDcomboBox.Text != "")
            {
                string cur_path = AppDomain.CurrentDomain.BaseDirectory;
                des_path = cur_path;
                des_path = Path.Combine(cur_path, txtFolder.Text);
                if (Directory.Exists(des_path) || IsValidPath(des_path) == false)
                {
                    MessageBox.Show("This folder cannot be created");
                }
                else
                {
                    //SelectedHDD = new string;
                    SelectedHDD = HDDcomboBox.Text;



                    result form = new result();                    
                    this.Hide();
                    form.Show();
                    
                    //form.carve();
                }
            }
        }

        private void HDDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
