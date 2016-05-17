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
    public partial class result : MaterialForm
    {
        public result()
        {
            InitializeComponent();
            Carve carve = new Carve();
            carve.searchHF(main.SelectedHDD);
            Console.WriteLine("HDD = {0}", main.SelectedHDD);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search form = new search();
            this.Hide();
            form.Show();
        }


    }
}
