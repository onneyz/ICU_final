using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Documents;
using Lucene.Net.Analysis;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;
using TikaOnDotNet.TextExtraction;

using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;
using System.Windows.Forms;

namespace ICU_FINAL
{
    class ExtractSearch
    {
        //Do extraction in TIKA
        public ExtractSearchResults extractTika(string fileAddress)
        {
            ExtractSearchResults resultObject = new ExtractSearchResults();
            fileAddress = Environment.CurrentDirectory + "\\Documents\\carved.docx";

            Console.WriteLine("*** Start Extracting ***");

            TextExtractor tikaExtractor = new TextExtractor();
            var result = tikaExtractor.Extract(fileAddress);

            string fileName = fileAddress.Split('\\').Last();
            resultObject.docText = result.Text;
            resultObject.fileName = fileName;
            resultObject.fileAddress = fileAddress;

            Console.WriteLine("*** End Extracting ***");

            // return ExtractPieces class with assigned attributes
            return resultObject;

        }

        // Do index document
        public void indexingDoc(string docText, ExtractSearchResults extractedResults)
        {
            Console.WriteLine("*** Start Indexing ***");

            var doc = new Document();
            doc.Add(new Field("FileName", extractedResults.fileName, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("FileAddress", extractedResults.fileAddress, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Content", docText, Field.Store.YES, Field.Index.ANALYZED));

            Directory directory = FSDirectory.Open(new DirectoryInfo(Environment.CurrentDirectory + "\\LuceneIndex"));
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);

            var writter = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);

            writter.AddDocument(doc);

            writter.Optimize();
            writter.Close();

            Console.WriteLine("*** End Indexing ***");
        }

        // Do search and display result in listBox
        public void doSearch(TextBox searchTextBox, ListBox searchResultBox)
        {
            Console.WriteLine("*** Start Searching ***");
            Directory directory = FSDirectory.Open(new DirectoryInfo(Environment.CurrentDirectory + "\\LuceneIndex"));
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);

            IndexReader indexReader = IndexReader.Open(directory, true);

            Searcher indexSearch = new IndexSearcher(indexReader);

            var queryParser = new QueryParser(Version.LUCENE_29, "Content", analyzer);
            var query = queryParser.Parse(searchTextBox.Text);

            Console.WriteLine("Searching for .." + query);

            TopDocs resultDocs = indexSearch.Search(query, indexReader.MaxDoc);

            var hits = resultDocs.ScoreDocs;
            foreach (var hit in hits)
            {
                var documentFromSearch = indexSearch.Doc(hit.Doc);
                searchResultBox.Items.Add(documentFromSearch.Get("FileName") + " | "
                    + documentFromSearch.Get("FileAddress"));
                //Console.WriteLine(documentFromSearch.Get("Content"));
            }
            Console.WriteLine("*** End Searching ***");
        }
    }
    
    class ExtractSearchResults{

        public string docText { get; set; }

        public string fileAddress { get; set; }

        public string fileName { get; set; }
    }
}
