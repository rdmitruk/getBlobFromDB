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

        public static void unZip(FileInfo filetoExtract)
        {
            if (Directory.Exists(HttpContext.Current.Server.MapPath(@"~/docs/")) == true)
            {

                Directory.Delete(HttpContext.Current.Server.MapPath(@"~/docs/unzipped/"), true);

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/docs/unzipped"));
                    
                Directory.SetCurrentDirectory(HttpContext.Current.Server.MapPath("/docs/unzipped"));

                string zipPath = filetoExtract.FullName;
                string extractpath = HttpContext.Current.Server.MapPath(@"/docs/unzipped/");

                ZipFile.ExtractToDirectory(zipPath, extractpath);
            }
        }

    }
}