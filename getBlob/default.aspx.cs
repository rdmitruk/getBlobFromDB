using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace getBlob
{
    public partial class _default : System.Web.UI.Page
    {
        
        protected void btnGetFile_Click(object sender, EventArgs e)
        {
            getBlob.Classes.DataFunctions gb = new getBlob.Classes.DataFunctions();
            getBlob.Classes.CompressionFunctions cf = new getBlob.Classes.CompressionFunctions();

            gb.getBlob(20000);
            cf.decompressFile(HttpContext.Current.Server.MapPath("docs"));
        }
    }
}