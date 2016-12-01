<%@ WebHandler Language="C#" Class="img" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

public class img : HttpTaskAsyncHandler {

    public async override Task ProcessRequestAsync (HttpContext context) {
        string keywords = null;
        keywords = HttpContext.Current.Request.Url.ToString();
        await Task.Run( () => doit(context,keywords));
    }
    public void doit(HttpContext context, string keywords)
    {
        string[] b = keywords.Split('/');
        string[] c = b[b.Length - 1].Split('.');
        int typeid = Convert.ToInt32(c[0]);
        EVE_Central.BLL.api api = new EVE_Central.BLL.api();
        Bitmap bitm = api.eve_historyimg(typeid);
        MemoryStream   ms   =   new   MemoryStream();
        bitm.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[]   bytes=   ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释


        //context.Response.BinaryWrite(bytes);
        context.Response.ClearHeaders();
        context.Response.ContentEncoding = Encoding.UTF8;
        context.Response.ContentType = "image/jpeg";
        context.Response.Charset = "UTF-8";
        context.Response.Buffer = true;
        context.Response.Clear();
        ms.WriteTo( context.Response.OutputStream);
        ms.Close();
        context.Response.Flush();
        context.Response.End();
        ; ; ;


    }
    public bool  IsReusable {
        get {
            return false;
        }
    }

}