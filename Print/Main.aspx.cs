using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.Parameters;

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Print.Model;
using DevExpress.XtraReports.UI;
using Print.Http;


namespace Print
{
    public partial class Main : System.Web.UI.Page
    {

        public string webApiUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["webApiUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["flag"] != null)
                {
                    string tag = Request.Form["flag"];
                    string date = Request.Form["parameter1"];
                    string url = webApiUrl + "";
                    string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string data = HttpTool.Post(url, "", time);//url请求得到数据
                    String palletno = Server.UrlDecode(Request.Form["PalletList"]);
                }
            }
        }




        //public void PrintWorkOrder(StockLabel model)
        //{
          
        //        WorkOrder_Label raw = new WorkOrder_Label(model);
        //        raw.CreateDocument();//60x40
        //        for (int i = 1; i < model.Printqty; i++)
        //        {
        //            WorkOrder_Label raw1 = new WorkOrder_Label(model);
        //            raw1.CreateDocument();//60x40
        //            raw.Pages.AddRange(raw1.Pages);
        //        }
        //        this.ASPxWebDocumentViewer1.OpenReport(raw);
        

        //}








    }
}