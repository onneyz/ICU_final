using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;



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
                ulong curB = 7667712 * d.Geometry.BytesPerSector;
                for (int i = 0; i < fileformats.ListOfEnFileType.Count();i++ )
                {
                    MessageBox.Show(BitConverter.ToString(fileformats.ListOfEnFileType[i].header));
                }
                int carvedCount = 0;    // count the number of carved file
                int ind_stop = 0;       // start/stop copying indicator


                string TextInSector = string.Empty;
                string HexStream = string.Empty;
                while (curB / d.Geometry.BytesPerSector < totalsector)
                {
                    Console.WriteLine("curS < T : {0} < {1}", curB / d.Geometry.BytesPerSector, totalsector);
                    // อ่าน ที่ sector แรก ไป n sector แล้วเอาถ้วยไปใส่ เริ่มที่ 0ffset 0
                    int count = d.ReadSectors(curB / d.Geometry.BytesPerSector, (ulong)sectorsToRead, buffer, 0);
                    Console.WriteLine("sector to read = {0}  buffersize = {1}  count = {2} ", sectorsToRead, bufferSize, count);

                    if (count == sectorsToRead)
                    {
                        for (int i = 0; i < bufferSize; i += 512)
                        {
                            //if()
                            //{

                            //}

                            //if (i % d.Geometry.BytesPerSector == 0)
                            //{
                            //    //find header match
                            //        //start copying
                            //}
                            ////if (has footer in this sector)
                            //    //stop copying
                            //    // write file



                        }
                        curB = curB + (ulong)bufferSize;
                        Console.WriteLine("update currentsector = --------------{0}", curB / d.Geometry.BytesPerSector);
                        //TheText += new string('-', 53) + "\n";
                        //richTextBox1.Text = TheText;


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
    }
}
