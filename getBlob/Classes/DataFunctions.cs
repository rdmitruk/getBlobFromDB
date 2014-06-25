using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data; 
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.CSharp;

namespace getBlob.Classes
{
    public class DataFunctions
    {

        public void getBlob(int parent_refno)
        {
            string connStr = "Data Source=192.168.45.17;Initial Catalog=NLS;User Id=gvandell;Password=$#Escher1;";
            string sPath = null;
            int bufferSize = 100;
            byte[] outbyte = new byte[bufferSize];
            SqlConnection CN = new SqlConnection();
            SqlCommand CM = new SqlCommand();
            FileStream FS = null;
            BinaryWriter BW = null;
            long retVal;
            int StartIndex;    
        
            CN.ConnectionString = connStr;
            CN.Open();

            CM.Connection = CN;
            CM.CommandType = CommandType.Text;
            CM.CommandText = "select VerificationDocsID, DocumentBIN from GlobalVerificationDocs where VerificationDocsID in (select top 1 VerificationDocsID from vw_doc_packets where parent_refno = " + parent_refno + " and grouping_name = '" + "Unsecured Doc Packet" + "' order by VerificationDocsID desc)";

            SqlDataReader sqlDR = CM.ExecuteReader(CommandBehavior.SequentialAccess);
            while (sqlDR.Read())
            {
                sPath = HttpContext.Current.Server.MapPath("/docs/");
                //FS = new FileStream(HttpContext.Current.Server.MapPath("/docs/" + parent_refno + "_" + DateTime.Today.ToShortDateString() + ".zip"), FileMode.OpenOrCreate, FileAccess.Write);
                FS = new FileStream(HttpContext.Current.Server.MapPath("/docs/SFC_" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + ".zip"), FileMode.OpenOrCreate, FileAccess.Write);

                BW = new BinaryWriter(FS);

                StartIndex = 0;
                retVal = sqlDR.GetBytes(1, StartIndex, outbyte, 0, bufferSize);

                while (retVal == bufferSize)
                {
                    BW.Write(outbyte, 0, (int)retVal);
                    BW.Flush();

                    StartIndex += bufferSize;
                    retVal = sqlDR.GetBytes(1, StartIndex, outbyte, 0, bufferSize);

                }

                BW.Write(outbyte, 0, (int)retVal);
                BW.Flush();

                BW.Close();
                FS.Close();
            }

            sqlDR.Close();
            CN.Close();

        }
    }
}