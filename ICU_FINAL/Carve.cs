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

        public void searchHF(string HDD)
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
                //    Console.WriteLine(BitConverter.ToString(ListOfEnFileType[i].header));
                //}


                byte[] BufferToWrite = new byte[0];
                byte[] BuffSector = new byte[(int)d.Geometry.BytesPerSector];
                int ind_copy = 0;
                char mode = 'H';
                long maxsize = -1;
                ulong copiedSectorCount = 0;
                int FileCount = 0;
                string ext = "";
                int idx = -1;
                //ExtractSearch extractSearch = new ExtractSearch();



                while (curB / d.Geometry.BytesPerSector < totalsector)
                {
                    int count = d.ReadSectors(curB / d.Geometry.BytesPerSector, (ulong)sectorsToRead, buffer, 0);
                    //Console.WriteLine("sector to read = {0}  buffersize = {1}  count = {2} ", sectorsToRead, bufferSize, count);
                    if (count == sectorsToRead)
                    {
                        for (int i = 0; i < bufferSize; i += (int)d.Geometry.BytesPerSector) // i = byte
                        {
                            Buffer.BlockCopy(buffer, i, BuffSector, 0, (int)d.Geometry.BytesPerSector);
                            if (mode == 'H')
                            {
                                //Console.WriteLine("mode H");
                                for (int j = 0; j < fileformats.ListOfEnFileType.Count; j++)
                                {
                                    //Console.WriteLine("check for H : {0}", ListOfEnFileType[j].extension);
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
                                        File.WriteAllBytes(FileCount + "." + ext, BufferToWrite);
                                        //BufferToWrite
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
                                BufferToWrite = Combine(BufferToWrite, BuffSector);
                                //Console.WriteLine(BitConverter.ToString(BufferToWrite));
                                copiedSectorCount++;
                            }
                            if (mode == 'F' && ind_copy == 1)
                            {
                                if (ext == "doc" || ext == "ppt" || ext == "xls")
                                {

                                    for (int j = 0; j < fileformats.ListOfEnFileType.Count; j++)
                                    {
                                        if (CheckPatternInArray(fileformats.ListOfEnFileType[j].footer, BuffSector))
                                        {
                                            Console.WriteLine("in check dup ext----- found real ext = {0} ", fileformats.ListOfEnFileType[j].extension);
                                            idx = j;
                                            ext = fileformats.ListOfEnFileType[j].extension;
                                        }
                                    }
                                }
                                if (CheckPatternInArray(fileformats.ListOfEnFileType[idx].footer, BuffSector))
                                {
                                    Console.WriteLine("----------------------found footer of {0}", fileformats.ListOfEnFileType[idx].extension);
                                    FileCount++;
                                    string fileName = main.des_path+"\\"+FileCount + "." + ext;
                                    File.WriteAllBytes(fileName, BufferToWrite);
                                    Console.WriteLine("/////////// wrote file : {0}\\{1}.{2} ******* {3}",main.des_path, FileCount, ext, copiedSectorCount);
                                    //filelistBox.Items.Add(fileName);
                                    //var extractedResults = extractSearch.extractTika(fileName);
                                    //extractSearch.indexingDoc(extractedResults.docText, extractedResults);
                                    Array.Clear(BufferToWrite, 0, BufferToWrite.Length);
                                    ind_copy = 0;
                                    copiedSectorCount = 0;
                                    mode = 'H';
                                    ext = "";
                                    idx = -1;
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
