using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILWeb.OutStock
{
    public class T_OutStockInfo : BILBasic.Basing.Base_Model
    {
        //无参构造函数
        public T_OutStockInfo() : base() { }


        //私有变量
        private string customercode;
        private string customername;
        private decimal? isoutstockpost;
        private decimal? isundershelvepost;
        private string plant;
        private string plantname;
        private string movetype;
        private string supcode;
        private string supname;       
        private string movereasoncode;
        private string movereasondesc;
        private decimal? reviewstatus;
        private DateTime? outstockdate;
       



        //公开属性
        [Display(Name="客户编号")]
        public string CustomerCode
        {
            get
            {
                return customercode;
            }
            set
            {
                customercode = value;
            }
        }
        [Display(Name = "客户名")]
        public string CustomerName
        {
            get
            {
                return customername;
            }
            set
            {
                customername = value;
            }
        }

        public decimal? IsOutStockPost
        {
            get
            {
                return isoutstockpost;
            }
            set
            {
                isoutstockpost = value;
            }
        }

        public decimal? IsUnderShelvePost
        {
            get
            {
                return isundershelvepost;
            }
            set
            {
                isundershelvepost = value;
            }
        }

        public string Plant
        {
            get
            {
                return plant;
            }
            set
            {
                plant = value;
            }
        }

        public string PlantName
        {
            get
            {
                return plantname;
            }
            set
            {
                plantname = value;
            }
        }

        public string MoveType
        {
            get
            {
                return movetype;
            }
            set
            {
                movetype = value;
            }
        }
        [Display(Name = "供应商编号")]
        public string SupCode
        {
            get
            {
                return supcode;
            }
            set
            {
                supcode = value;
            }
        }
        [Display(Name = "供应商")]
        public string SupName
        {
            get
            {
                return supname;
            }
            set
            {
                supname = value;
            }
        }

        

        public string MoveReasonCode
        {
            get
            {
                return movereasoncode;
            }
            set
            {
                movereasoncode = value;
            }
        }

        public string MoveReasonDesc
        {
            get
            {
                return movereasondesc;
            }
            set
            {
                movereasondesc = value;
            }
        }

        public decimal? ReviewStatus
        {
            get
            {
                return reviewstatus;
            }
            set
            {
                reviewstatus = value;
            }
        }

        public DateTime? OutStockDate
        {
            get
            {
                return outstockdate;
            }
            set
            {
                outstockdate = value;
            }
        }
        [Display(Name = "单据号")]
        public string VoucherNo { get; set; }

        public string Note { get; set; }

        /// <summary>
        /// 发料日期
        /// </summary>
        public DateTime? FromShipmentDate { get; set; }

        /// <summary>
        /// 发料日期
        /// </summary>
        public DateTime? ToShipmentDate { get; set; }

        public bool OKSelect { get; set; }

        public int StrongHoldType { get; set; }

        public int MStockStatus { get; set; }

        public decimal? StockQty { get; set; }

        public decimal? OutStockQty { get; set; }

        public List<T_OutStockDetailInfo> lstDetail { get; set; }

        [Display(Name = "省份")]
        public string Province { get; set; }

        [Display(Name = "市")]
        public string City { get; set; }

        [Display(Name = "区")]
        public string Area { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "物流地址")]
        public string Address1 { get; set; }

        [Display(Name = "联系人")]
        public string Contact { get; set; }

        [Display(Name = "电话")]
        public string Phone { get; set; }
        

        [Display(Name = "等通知发货")]
        public string ShipNFlg { get; set; }

        [Display(Name = "是否需要发货清单标记")]
        public string ShipDFlg { get; set; }

        [Display(Name = "打印发货清单是否要价格")]
        public string ShipPFlg { get; set; }
        [Display(Name = "是否等外调标记")]
        public string ShipWFlg { get; set; }

        [Display(Name = "交易条件")]
        public string TradingConditions { get; set; }

        [Display(Name = "交易条件")]
        public string TradingConditionsName { get; set; }

        public string ExpAmount { get; set; }

        /// <summary>
        /// 拣货车编码
        /// </summary>
        [Display(Name = "拣货车编码")]
        public string CarNo { get; set; }

        public string strReviewUserNo { get; set; }

        public string hmdocno { get; set; }

        public string fydocno { get; set; }
    }
}
