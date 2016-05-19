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
using System.Collections;


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

            List<string> fileAddressList = new List<string>();
            fileAddressList.Add(Environment.CurrentDirectory + "\\Documents\\desert.pdf");
            fileAddressList.Add(Environment.CurrentDirectory + "\\Documents\\bear.docx");
            fileAddressList.Add(Environment.CurrentDirectory + "\\Documents\\oil.docx");


            for (int i = 0; i < fileAddressList.Count; i++)
            {
                //Console.WriteLine(fileAddressList[i]);
                //ExtractSearch extractor = new ExtractSearch();
                //var extractedResults = extractor.extractTika(fileAddressList[i]);
                //extractor.indexingDoc(extractedResults.docText, extractedResults);
            }

            ExtractSearch searcher = new ExtractSearch();
            searcher.doSearch(searchBox, searchResultBox);
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

            string filePath = main.des_path;
            var resultList = searchResultBox.Items.Cast<String>().ToList();
            using (StreamWriter outputFile = new StreamWriter(filePath + @"\search-results.txt", false))
            {
                resultList.ForEach(result => outputFile.WriteLine(result));   
            }

            Console.WriteLine("*** End Writting text file ***");

        }
    }
}
