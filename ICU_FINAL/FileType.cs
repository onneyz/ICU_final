using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICU_FINAL
{
    public class FileType
    {
        public string extension;
        public byte[] header = new byte[0];
        public byte[] footer = new byte[0];
        public long maxsize;
        //int ind_stop;

        public string Extension { get { return extension; } set { extension = value; } }
        public byte[] Header { get { return header; } set { header = value; } }
        public byte[] Footer { get { return footer; } set { footer = value; } }
        public long Maxsize { get { return maxsize; } set { maxsize = value; } }
        //public int Ind_stop { get { return ind_stop; } }


        public FileType setTypeFeild(string Ext)
        {
            FileType ext = new FileType();
            switch (Ext)
            {
                case "docx":
                    {
                        ext.extension = "docx";
                        ext.header = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 };
                        ext.footer = new byte[] { 0x64, 0x6F, 0x63, 0x50, 0x72, 0x6F, 0x70, 0x73, 0x2F, 0x61, 0x70, 0x70, 0x2E, 0x78, 0x6D, 0x6C, 0x50, 0x4B };
                        ext.maxsize = -1;
                    }
                    break;
                case "doc":
                    {
                        ext.extension = "doc";
                        ext.header = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 };
                        ext.footer = new byte[] { 0x57, 0x6F, 0x72, 0x64, 0x2E, 0x44, 0x6F, 0x63, 0x75, 0x6D, 0x65, 0x6E, 0x74, 0x2E };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;
                case "ppt":
                    {
                        ext.extension = "ppt";
                        ext.header = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 };
                        ext.footer = new byte[] { 0x50, 0x00, 0x6F, 0x00, 0x77, 0x00, 0x65, 0x00, 0x72, 0x00, 0x50, 0x00, 0x6F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x20, 0x00, 0x44, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74 };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;
                case "xls":
                    {
                        ext.extension = "xls";
                        ext.header = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 };
                        ext.footer = new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6B, 0x00, 0x62, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x6B, 0x00 };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;
                case "gif":
                    {
                        ext.extension = "gif";
                        ext.header = new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 };
                        ext.footer = new byte[] { 0xFE, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6B, 0x00, 0x62, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x6B, 0x00 };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;
                case "jpg":
                    {
                        ext.extension = "jpg";
                        ext.header = new byte[] { 0xFF, 0xD8 };
                        ext.footer = new byte[] { 0xFF, 0xD9 };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;
                case "pdf":
                    {
                        ext.extension = "pdf";
                        ext.header = new byte[] { 0x25, 0x50, 0x44, 0x46 };
                        ext.footer = new byte[] { 0x25, 0x25, 0x45, 0x4F, 0x46 };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;
                case "png":
                    {
                        ext.extension = "png";
                        ext.header = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
                        ext.footer = new byte[] { 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;
                case "zip":
                    {
                        ext.extension = "zip";
                        ext.header = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14 };
                        ext.footer = new byte[] { 0x50, 0x4B, 0x05, 0x06, 0x00 };
                        ext.maxsize = -1;
                        //docx.ind_stop = 1;
                    }
                    break;


            }
            return ext;
        }
    }
}
