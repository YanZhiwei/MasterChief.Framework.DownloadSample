using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterChief.DotNet.Framework.Download;

namespace MasterChief.DotNet.Framework.WbSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = DownloadFileContext.Instance.EncryptFileName("typora-setup-x64.exe");
            link.NavigateUrl = "~/FileDownloadHandler.ashx?fileName=" + url;
        }
    }
}