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

namespace ICU_FINAL
{
    public partial class fileformats : MaterialForm
    {
        public static List<FileType> ListOfEnFileType;

        public fileformats()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FileType EXT = new FileType();
            ListOfEnFileType = new List<FileType>();

            for (int i = 0; i < formatsListBox.CheckedItems.Count; i++)
            {
                // Use the IndexOf method to get the index of an item.
                string[] tokens = formatsListBox.CheckedItems[i].ToString().Split(' ');
                string ext = tokens[0];
                if (ext == "gif")
                {
                    ListOfEnFileType.Add(EXT.setTypeFeild("gif87a"));
                    ListOfEnFileType.Add(EXT.setTypeFeild("gif89a"));
                }
                else
                //MessageBox.Show("Item with title: \"" + ext);
                    ListOfEnFileType.Add(EXT.setTypeFeild(ext));

            }

           

            this.Close();
        }
    }
}
