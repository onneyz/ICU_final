using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;



namespace ICU_FINAL
{
    public class Carve
    {
        public void testCountList()
        {
            Console.WriteLine(fileformats.ListOfEnFileType.Count);
        }

        public void searchHF(string HDD, ListBox filelistBox,Form f,ProgressBar progressBar)
        {


            DriveAccess d = null;
            d = new DriveAccess(@"\\.\" + HDD);
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                const int sectorsToRead = 32768;
                int bufferSize = (int)d.Geometry.BytesPerSector * sectorsToRead;
                byte[] buffer = new byte[bufferSize];
                ulong totalsector = d.Geometry.TotalSectors;
                ulong curB = 0;//7667712 * d.Geometry.BytesPerSector;
                //for (int i = 0; i < ListOfEnFileType.Count(); i++)
                //{
                    Console.WriteLine("start carving");
                //}

                var BufferToWrite = new List<byte>();
                //byte[] BufferToWrite = new byte[0];
                byte[] BuffSector = new byte[(int)d.Geometry.BytesPerSector];
                int ind_copy = 0;
                char mode = 'H';
                long maxsize = -1;
                ulong copiedSectorCount = 0;
                int FileCount = 0;
                string ext = "";
                int idx = -1;
                ExtractSearch extractor = new ExtractSearch();

                var ListOfMSFooter = new List<FileType>();
                for (int j = 0; j < fileformats.ListOfEnFileType.Count(); j++)
                {
                    byte[] MSHeader = {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1};
                    if (Compare(fileformats.ListOfEnFileType[j].header,MSHeader,0 ))
                    {
                        ListOfMSFooter.Add(fileformats.ListOfEnFileType[j]);
                        Console.WriteLine("add footer : {0} to LoMSF  =    {1}", BitConverter.ToString(fileformats.ListOfEnFileType[j].footer), fileformats.ListOfEnFileType[j].extension);
                    }
                }

                var ListOfMSxFooter = new List<FileType>();
                for (int j = 0; j < fileformats.ListOfEnFileType.Count(); j++)
                {
                    byte[] MSHeader = { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 };
                    if (Compare(fileformats.ListOfEnFileType[j].header, MSHeader, 0))
                    {
                        ListOfMSxFooter.Add(fileformats.ListOfEnFileType[j]);
                        Console.WriteLine("add footer : {0} to LoMSxF  =    {1}", BitConverter.ToString(fileformats.ListOfEnFileType[j].footer), fileformats.ListOfEnFileType[j].extension);
                    }
                }

                f.Invoke((MethodInvoker)delegate
                {
                    progressBar.Maximum = (int)totalsector;
                    progressBar.Minimum = 0;
                });
                while (curB / d.Geometry.BytesPerSector < totalsector)
                {
                    f.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value = (int)(curB / d.Geometry.BytesPerSector);
                    });
                    int count = d.ReadSectors(curB / d.Geometry.BytesPerSector, (ulong)sectorsToRead, buffer, 0);
                    //Console.WriteLine("sector to read = {0}  buffersize = {1}  count = {2} ", sectorsToRead, bufferSize, count);
                    if (count == sectorsToRead)
                    {
                        for (int i = 0; i < bufferSize; i += (int)d.Geometry.BytesPerSector) // i = byte
                        {
                            //if(copiedSectorCount > 50000)
                            //{
                            //    BufferToWrite.Clear();
                            //    copiedSectorCount = 0;
                            //    ext = "";
                            //    idx = -1;
                            //    ind_copy = 0;
                            //}
                            Buffer.BlockCopy(buffer, i, BuffSector, 0, (int)d.Geometry.BytesPerSector);
                            if (mode == 'H')
                            {
                                //Console.WriteLine("mode H");
                                for (int j = 0; j < fileformats.ListOfEnFileType.Count; j++)
                                {
                                    //Console.WriteLine("check for H : {0}", fileformats.ListOfEnFileType[j].extension);
                                    if ((ind_copy == 0) && (Compare(fileformats.ListOfEnFileType[j].header, BuffSector, 0)))
                                    {
                                        Console.WriteLine("no dup header found ---- H = {0}, ext = {1}", BitConverter.ToString(fileformats.ListOfEnFileType[j].header), fileformats.ListOfEnFileType[j].extension);
                                        idx = j;
                                        ind_copy = 1;
                                        ext = fileformats.ListOfEnFileType[j].extension;
                                        if (fileformats.ListOfEnFileType[j].maxsize < 0)
                                            mode = 'F';
                                        break;
                                    }
                                    else if ((ind_copy == 1) && (Compare(fileformats.ListOfEnFileType[j].header, BuffSector, 0)))
                                    {
                                        Console.WriteLine("dup header found ---- H = {0}, ext = {1}", BitConverter.ToString(fileformats.ListOfEnFileType[j].header), fileformats.ListOfEnFileType[j].extension);
                                        FileCount++;
                                        byte[] s  = BufferToWrite.ToArray();
                                        File.WriteAllBytes(FileCount + "." + ext, s);
                                        BufferToWrite.Clear();
                                        copiedSectorCount = 0;
                                        ext = "";
                                        idx = -1;

                                        ext = fileformats.ListOfEnFileType[j].extension;
                                        idx = j;
                                        if (fileformats.ListOfEnFileType[j].maxsize < 0)
                                            mode = 'F';
                                        break;
                                    }
                                }
                            }
                            if (ind_copy == 1)
                            {
                                List<byte> l = BuffSector.ToList();
                                BufferToWrite.AddRange(l);
                                //BufferToWrite = Combine(BufferToWrite, BuffSector);
                                //Console.WriteLine(BitConverter.ToString(BufferToWrite));
                                copiedSectorCount++;
                                //Console.WriteLine("copied sector count = {0}", copiedSectorCount);
                            }
                            if (mode == 'F' && ind_copy == 1)
                            {
                                if (ext == "doc" || ext == "ppt" || ext == "xls")
                                {
                                    for (int j = 0; j < ListOfMSFooter.Count; j++)
                                    {
                                        if (CheckPatternInArray(ListOfMSFooter[j].footer, BuffSector))
                                        {

                                            Console.WriteLine("in check dup ext----- found real ext = {0} ", (ListOfMSFooter[j].extension));
                                            idx = j;
                                            ext = ListOfMSFooter[j].extension;
                                            FileCount++;
                                            string fileName = main.des_path+"\\"+FileCount + "." + ext;
                                            byte[] s = BufferToWrite.ToArray();
                                            File.WriteAllBytes(fileName, s);
                                            Console.WriteLine("/////////// wrote file : {0}\\{1}.{2} ******* {3}",main.des_path, FileCount, ext, copiedSectorCount);
                                            f.Invoke((MethodInvoker)delegate
                                            {
                                                 filelistBox.Items.Add(fileName);
                                                 progressBar.Value = (int)(curB / d.Geometry.BytesPerSector);
                                            });
                                            var extractedResults = extractor.extractTika(fileName);
                                            extractor.indexingDoc(extractedResults.docText, extractedResults);
                                           
                                            //var extractedResults = extractSearch.extractTika(fileName);
                                            //extractSearch.indexingDoc(extractedResults.docText, extractedResults);
                                            BufferToWrite.Clear();
                                            ind_copy = 0;
                                            copiedSectorCount = 0;
                                            mode = 'H';
                                            ext = "";
                                            idx = -1;
                                            
                                        }
                                    }
                                }
                                else if (ext == "docx" || ext == "pptx" || ext == "xlsx")
                                {
                                    for (int j = 0; j < ListOfMSxFooter.Count; j++)
                                    {
                                        if (CheckPatternInArray(ListOfMSxFooter[j].footer, BuffSector))
                                        {

                                            Console.WriteLine("in check dup ext----- found real ext = {0} ", (ListOfMSxFooter[j].extension));
                                            idx = j;
                                            ext = ListOfMSxFooter[j].extension;
                                            FileCount++;
                                            string fileName = main.des_path + "\\" + FileCount + "." + ext;
                                            byte[] s = BufferToWrite.ToArray();
                                            File.WriteAllBytes(fileName, s);
                                            Console.WriteLine("/////////// wrote file : {0}\\{1}.{2} ******* {3}", main.des_path, FileCount, ext, copiedSectorCount);
                                            f.Invoke((MethodInvoker)delegate
                                            {
                                                filelistBox.Items.Add(fileName);
                                                
                                            });
                                            var extractedResults = extractor.extractTika(fileName);
                                            extractor.indexingDoc(extractedResults.docText, extractedResults);
                                            //var extractedResults = extractSearch.extractTika(fileName);
                                            //extractSearch.indexingDoc(extractedResults.docText, extractedResults);
                                            BufferToWrite.Clear();
                                            ind_copy = 0;
                                            copiedSectorCount = 0;
                                            mode = 'H';
                                            ext = "";
                                            idx = -1;

                                        }
                                    }
                                }
                                else // (CheckPatternInArray(fileformats.ListOfEnFileType[idx].footer, BuffSector))
                                {
                                    if(CheckPatternInArray(fileformats.ListOfEnFileType[idx].footer, BuffSector))
                                    {
                                        Console.WriteLine("----------------------found footer of {0}", fileformats.ListOfEnFileType[idx].extension);
                                        FileCount++;
                                        string fileName = main.des_path+"\\"+FileCount + "." + ext;
                                        byte[] s = BufferToWrite.ToArray();
                                        File.WriteAllBytes(fileName, s);
                                        Console.WriteLine("/////////// wrote file : {0}\\{1}.{2} ******* {3}",main.des_path, FileCount, ext, copiedSectorCount);
                                        f.Invoke((MethodInvoker)delegate
                                        {
                                            filelistBox.Items.Add(fileName);
                                        });
                                        var extractedResults = extractor.extractTika(fileName);
                                        extractor.indexingDoc(extractedResults.docText, extractedResults);
                                        //var extractedResults = extractSearch.extractTika(fileName);
                                        //extractSearch.indexingDoc(extractedResults.docText, extractedResults);
                                        BufferToWrite.Clear();
                                        ind_copy = 0;
                                        copiedSectorCount = 0;
                                        mode = 'H';
                                        ext = "";
                                        idx = -1;
                                    }
                                }


                            }
                        }
                        curB = curB + (ulong)bufferSize;
                        //Console.WriteLine("update currentsector = --------------{0}", curB / d.Geometry.BytesPerSector); 

                    }
                    else
                    {
                        int S2R = sectorsToRead;
                        Console.WriteLine("\n\n\n---Enter else ,S2R = {0}", S2R);
                        while ((count = d.ReadSectors(curB / d.Geometry.BytesPerSector, (ulong)S2R, buffer, 0)) == 0 && S2R != 0)
                        {
                            S2R = S2R / 2;
                            Console.WriteLine("S2R = {0}", S2R);
                            count = d.ReadSectors(curB / d.Geometry.BytesPerSector, (ulong)S2R, buffer, 0);
                            if (count != 0)
                            {
                                Console.WriteLine("---- last chunk of sector ---- {0} sector left", count);
                                count = d.ReadSectors(curB / d.Geometry.BytesPerSector, (ulong)count, buffer, 0);
                                bufferSize = count * (int)d.Geometry.BytesPerSector;
                                Console.WriteLine("sector to read = {0}  buffersize = {1}  count = {2} ", count, bufferSize, count);


                                for (int i = 0; i < bufferSize; i += 512)
                                {
                                    if (i % d.Geometry.BytesPerSector == 0)
                                    {
                                        //find header match
                                        //start copying
                                    }
                                    //if (has footer in this sector)
                                    //stop copying
                                    // write file



                                }
                                curB = curB + (ulong)bufferSize;
                                Console.WriteLine("update currentsector = --------------{0}", curB / d.Geometry.BytesPerSector);
                            }

                        }
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("------ time : {0} -------", stopwatch.Elapsed);
                buffer = null;
                BuffSector = null;

                d.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (d != null) d.Dispose();
            }

        }
        private bool CheckPatternInArray(byte[] pattern, byte[] array)
        {
            int fidx = 0;
            int result = Array.FindIndex(array, 0, array.Length, (byte b) => 
            {
                fidx = (b == pattern[fidx]) ? fidx + 1 : 0;
                return (fidx == pattern.Length);
            });
            return (result >= pattern.Length - 1);
        }

        public static bool Compare(byte[] needle, byte[] array, int startIndex)
        {
            int needleLen = needle.Length;
            for (int i = 0, p = startIndex; i < needleLen; i++, p++)
            {
                if (array[p] != needle[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
    }
}
