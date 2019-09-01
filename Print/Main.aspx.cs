using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Print
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string flag = Request["flag"];
                string parameter1= Request["parameter1"];
                string parameter2 = Request["parameter2"];
                string parameter3 = Request["parameter3"];
                string parameter4 = Request["parameter4"];
                switch (flag)
                {
                    case "In": this.ASPxWebDocumentViewer1.OpenReport(new In(parameter1,1));break;//到货打印
                    case "StockDetail": this.ASPxWebDocumentViewer1.OpenReport(new In(parameter1,2)); break;//库存明细打印
                    case "First": this.ASPxWebDocumentViewer1.OpenReport(new In(parameter1, 3)); break;//期初打印
                    case "Out": this.ASPxWebDocumentViewer1.OpenReport(new In(parameter1,1)); break;
                    case "Express": this.ASPxWebDocumentViewer1.OpenReport(new Express()); break;//快递单子
                    case "Logistics": this.ASPxWebDocumentViewer1.OpenReport(new Logistics(parameter1, parameter2, parameter3)); break;//物流标签
                    case "Box": this.ASPxWebDocumentViewer1.OpenReport(new Box(parameter1, parameter2)); break;//装箱清单

                    case "BoxList": this.ASPxWebDocumentViewer1.OpenReport(new BoxList(parameter1)); break;//装箱汇总
                    case "DBOutList": this.ASPxWebDocumentViewer1.OpenReport(new DBOutList(parameter1)); break;//调拨单
                    case "FYSaleOutOutList": this.ASPxWebDocumentViewer1.OpenReport(new FYSaleOutOutList(parameter1)); break;//菲扬销退
                    case "HMSaleOutOutList": this.ASPxWebDocumentViewer1.OpenReport(new HMSaleOutOutList(parameter1)); break;//禾木销退
                    case "OutList": this.ASPxWebDocumentViewer1.OpenReport(new OutList(parameter1)); break;//杂项发料单子
                    case "WarehouseOutList": this.ASPxWebDocumentViewer1.OpenReport(new WarehouseOutList(parameter1)); break;//仓退
                    default:
                        break;
                }
            }
        }
    }
}