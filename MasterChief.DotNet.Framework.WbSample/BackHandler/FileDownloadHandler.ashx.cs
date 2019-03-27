using System.Web;
using MasterChief.DotNet.Framework.Download;

namespace MasterChief.DotNet.Framework.WbSample.BackHandler
{
    /// <summary>
    ///     FileDownloadHandler 的摘要说明
    /// </summary>
    public class FileDownloadHandler : DownloadHandler, IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var fileName = context.Request["fileName"];
            StartDownloading(context, fileName);
        }

        public bool IsReusable => false;

        public override void OnDownloadFailed(HttpContext context, string fileName, string filePath, string ex)
        {
            context.Response.Write(ex);
        }

        public override void OnDownloadSucceed(HttpContext context, string fileName, string filePath)
        {
            var result = $"文件[{fileName}]下载成功，映射路径：{filePath}";
            context.Response.Write(result);
        }
    }
}