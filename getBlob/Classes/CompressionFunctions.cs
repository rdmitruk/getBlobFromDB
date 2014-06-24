﻿using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getBlob.Classes
{
    public class CompressionFunctions
    {
        public void decompressFile(string sPath)
        {
            DirectoryInfo DI = new DirectoryInfo(sPath);

            foreach (FileInfo fi in DI.GetFiles())
            {
                unZip(fi);
            }
        }

        private static void unZip(FileInfo filetoExtract)
        {
            //string zipPath = HttpContext.Current.Server.MapPath("/docs/" + filetoExtract.);



            string zipPath = filetoExtract.FullName;
            string extractpath = HttpContext.Current.Server.MapPath("/docs/unzipped/");

            ZipFile.ExtractToDirectory(zipPath, extractpath);

        }

    }
}