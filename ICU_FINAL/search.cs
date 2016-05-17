using System;
using System.IO;
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
    public partial class search : MaterialForm
    {
        public search()
        {
            InitializeComponent();
        }

        private void search_Load(object sender, EventArgs e)
        {

        }

        // Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //ExtractSearch extractSearch = new ExtractSearch();
            //var extractedResults = extractSearch.extractTika("Hardcoded File Address");
            //extractSearch.indexingDoc(extractedResults.docText, extractedResults);
            //extractSearch.doSearch(searchBox, searchResultBox);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        // Export Text File
        private void btnExport_Click(object sender, EventArgs e)
        {
            Console.WriteLine("*** Start Writting text file ***");

            string filePath = Environment.CurrentDirectory + "\\Documents";
            var resultList = searchResultBox.Items.Cast<String>().ToList();
            using (StreamWriter outputFile = new StreamWriter(filePath + @"\search-results.txt", false))
            {
                resultList.ForEach(result => outputFile.WriteLine(result));   
            }

            Console.WriteLine("*** End Writting text file ***");

        }
    }
}
