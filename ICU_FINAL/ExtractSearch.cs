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

using DirectoryFolder = System.IO.Directory;
using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;
using System.Windows.Forms;

namespace ICU_FINAL
{
    class ExtractSearch
    {
        // Do extraction in TIKA
        public ExtractSearchResults extractTika(string fileAddress)
        {
            Console.WriteLine("*** Start Extracting file: " + fileAddress + " ***");
            ExtractSearchResults resultObject = new ExtractSearchResults();

            TextExtractor tikaExtractor = new TextExtractor();
            var result = tikaExtractor.Extract(fileAddress);

            string fileName = fileAddress.Split('\\').Last();
            resultObject.docText = result.Text;
            resultObject.fileName = fileName;
            resultObject.fileAddress = fileAddress;

            Console.WriteLine("*** End Extracting file: " + fileAddress + " ***");

            // return ExtractPieces class with assigned attributes
            return resultObject;

        }

        // Do index document
        public void indexingDoc(string docText, ExtractSearchResults extractedResults)
        {
            Console.WriteLine("*** Start Indexing ***");

            // check index dir
            if (!DirectoryFolder.Exists(main.des_path + "\\LuceneIndex"))
            {
                Console.WriteLine("Creating index directory");
                DirectoryFolder.CreateDirectory(main.des_path + "\\LuceneIndex");
            }

            // check initial files of index dir
            DirectoryInfo dir = new DirectoryInfo(main.des_path + "\\LuceneIndex");
            FileInfo[] requiredFiles = dir.GetFiles("*.gen");

            // if no file gen in dir
            if (requiredFiles.Length == 0)
            {
                Directory directory = FSDirectory.Open(main.des_path + "\\LuceneIndex");
                Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);
                Console.WriteLine("True Deletion");
                addDocument(true, docText, extractedResults, directory, analyzer);
            }
            else // if file gen already exists!
            {
                Directory directory = FSDirectory.Open(main.des_path + "\\LuceneIndex");
                Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);

                Console.WriteLine("False Deletion");
                // Check existing index document
                IndexReader reader = IndexReader.Open(directory, true);
                Term indexTerm = new Term("FileName", extractedResults.fileName);
                TermDocs docs = reader.TermDocs(indexTerm);
                if (docs.Next())
                {
                    Console.WriteLine("Documents EXISTS!");
                }
                else
                {
                    addDocument(false, docText, extractedResults, directory, analyzer);
                }
                
            }
            
            Console.WriteLine("*** End Indexing ***");
        }

        // Do search and display result in listBox
        public void doSearch(TextBox searchTextBox, ListBox searchResultBox)
        {
            Console.WriteLine("*** Start Searching ***");

            Directory directory = FSDirectory.Open(main.des_path + "\\LuceneIndex");
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);

            IndexReader indexReader = IndexReader.Open(directory, true);

            Searcher indexSearch = new IndexSearcher(indexReader);

            var queryParser = new QueryParser(Version.LUCENE_29, "Content", analyzer);
            var query = queryParser.Parse(searchTextBox.Text);

            Console.WriteLine("Searching for .." + query);

            TopDocs resultDocs = indexSearch.Search(query, indexReader.MaxDoc);

            searchResultBox.Items.Clear();

            var hits = resultDocs.ScoreDocs;
            if (hits.Length == 0)
            {
                searchResultBox.Items.Add("Results not found");
            }
            else
            {
                foreach (var hit in hits)
                {
                    var documentFromSearch = indexSearch.Doc(hit.Doc);
                    searchResultBox.Items.Add(documentFromSearch.Get("FileName") + " | "
                        + documentFromSearch.Get("FileAddress"));
                    //Console.WriteLine(documentFromSearch.Get("Content"));
                }
            }
            
            Console.WriteLine("*** End Searching ***");
        }

        // Add document method
        public void addDocument(Boolean deletion, string docText, ExtractSearchResults extractedResults, Directory directory, Analyzer analyzer)
        {
            Console.WriteLine("Adding new document...");
            var doc = new Document();
            doc.Add(new Field("FileName", extractedResults.fileName, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("FileAddress", extractedResults.fileAddress, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Content", docText, Field.Store.YES, Field.Index.ANALYZED));

            var writter = new IndexWriter(directory, analyzer, deletion, IndexWriter.MaxFieldLength.LIMITED);
            writter.AddDocument(doc);
            writter.Optimize();
            writter.Dispose();

        }
    }
    
    // Extract results data structure
    class ExtractSearchResults{

        public string docText { get; set; }

        public string fileAddress { get; set; }

        public string fileName { get; set; }
    }
}
