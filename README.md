# 文件下载示例
> 项目说明
>
> 1. 目前支持WebForm文件下载，后续支持Mvc
> 2. 支持下载文件加密以及下载限速
> 3. 项目源码：[MasterChief.DotNet.Framework.Download](https://github.com/YanZhiwei/MasterChief/tree/master/MasterChief.DotNet.Framework.Download)
> 4. Nuget：Install-Package MasterChief.DotNet.Framework.Download
> 5. 欢迎PR，欢迎Star；

#### 如何使用

1. 通过[MasterChief.DotNet.Core.Config](https://www.nuget.org/packages/MasterChief.DotNet.Core.Config/)构建下载配置文件

   ```xml
   <?xml version="1.0" encoding="utf-16"?>
   <DownloadConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                   FileNameEncryptorIv="0102030405060708090a0a0c0d010208"
                   FileNameEncryptorKey="DotnetDownloadConfig"
                   LimitDownloadSpeedKb="1024"
                   DownLoadMainDirectory="D:\OneDrive\软件\工具\">
   </DownloadConfig>
   ```

2. 在WebForm下新建一般处理程序，并实现DownloadHandler抽象类

   ```c#
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
   ```

3. 在WebForm下载文件加密显示

   ```c#
   protected void Page_Load(object sender, EventArgs e)
   {
       string url = DownloadFileContext.Instance.EncryptFileName("typora-setup-x64.exe");
       link.NavigateUrl = "~/FileDownloadHandler.ashx?fileName=" + url;
   }
   ```

4. 运行效果

   ![](https://kxi37g.dm.files.1drv.com/y4mz07s-7TWePH9-vdbzMh6bLSr54wYY1BKBCxZP2pq0XeW03rD77GGKUiWyNMKMKZg0jgAseQK1rkj04elBPRLTBhgCbp2Dhtf_Iy2yhDmMNeM03SXPicThVeg76G9C1FKCZrzr5pxjth2TiDzVV40gMOAvU7hhDm9GgIQRIiIvmMWgEQYYrfLRGnW1xO5vyDKmfYjAkfwnC2Mdaz7ArDBcg?width=504&height=112&cropmode=none)

   