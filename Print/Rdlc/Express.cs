using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Print.Model;
using System.Collections.Generic;

/// <summary>
/// Summary description for Express
/// </summary>
public class Express : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel10;
    private XRLine xrLine15;
    private XRLine xrLine4;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRLine xrLine11;
    private XRLine xrLine8;
    private XRLine xrLine7;
    private XRLine xrLine5;
    private XRLine xrLine3;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRBarCode xrBarCode1;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel19;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel9;
    private XRLabel xrLabel2;
    private XRLine xrLine6;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Express()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
        List<PrintModel> lists = new List<PrintModel>();
        for (int i = 0; i < 1; i++)
        {
            lists.Add(new PrintModel
            {
                Dc1 = i.ToString()
            });
        }
        objectDataSource1.DataSource = lists;
        this.Watermark.Text = "405";
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine15 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine11 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine8 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel9,
            this.xrLabel2,
            this.xrLine6,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel10,
            this.xrLine15,
            this.xrLine4,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLine11,
            this.xrLine8,
            this.xrLine7,
            this.xrLine5,
            this.xrLine3,
            this.xrLine2,
            this.xrLine1,
            this.xrBarCode1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 1302.584F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 254F;
            this.xrLabel19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(633.7501F, 84.26669F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(105.8334F, 59.2667F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "包裹";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 254F;
            this.xrLabel16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(633.7501F, 24.99999F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(105.8334F, 59.2667F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "快递";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(333.2292F, 621.4468F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(242.0582F, 35.1366F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "1235486654";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(333.2292F, 477.8566F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(391.1208F, 49.95325F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "1022131222333";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(52.91667F, 921.5901F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(686.6667F, 69.00342F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "FY-HH2-1920215841125";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(139.4837F, 1204.347F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(600.0999F, 45.72009F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "本包裹由菜鸟提供智慧技术支持";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(52.91667F, 721.7764F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(245.3169F, 66.46375F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "332-22";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(371.5001F, 138.8534F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(140.7834F, 30.90338F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = " 第1/1个";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(52.91667F, 138.8534F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(318.5834F, 30.90338F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "2019/08/22 19:02:33";
            // 
            // xrLine6
            // 
            this.xrLine6.BorderColor = System.Drawing.Color.Gray;
            this.xrLine6.Dpi = 254F;
            this.xrLine6.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine6.LineWidth = 3;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(24.99999F, 169.7568F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(15.21667F, 966.3826F);
            this.xrLine6.StylePriority.UseBorderColor = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 254F;
            this.xrLabel18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(52.91667F, 831.6313F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(87.8667F, 43.60339F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "1件";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 254F;
            this.xrLabel17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(140.7834F, 831.6313F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(598.8002F, 43.60339F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "文件";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(599.25F, 644.3069F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(140.3334F, 38.09985F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "签收栏";
            // 
            // xrLine15
            // 
            this.xrLine15.BorderColor = System.Drawing.Color.Gray;
            this.xrLine15.Dpi = 254F;
            this.xrLine15.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine15.LineWidth = 3;
            this.xrLine15.LocationFloat = new DevExpress.Utils.PointFloat(589.3002F, 602.3966F);
            this.xrLine15.Name = "xrLine15";
            this.xrLine15.SizeF = new System.Drawing.SizeF(9.949768F, 210.3969F);
            this.xrLine15.StylePriority.UseBorderColor = false;
            // 
            // xrLine4
            // 
            this.xrLine4.BorderColor = System.Drawing.Color.Gray;
            this.xrLine4.Dpi = 254F;
            this.xrLine4.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine4.LineWidth = 3;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(298.2336F, 721.7764F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(10.63333F, 91.01715F);
            this.xrLine4.StylePriority.UseBorderColor = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(139.4837F, 621.4467F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(158.7499F, 60.96008F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "周萌萌";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(139.4837F, 682.4068F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(449.8165F, 31.74963F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "金华市义乌市";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(139.4837F, 527.8099F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(589.5165F, 70.69659F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "上海市普陀区中心城市";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(134.8335F, 477.8566F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(140.7831F, 49.95325F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "张";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(52.91667F, 621.4468F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(76.2F, 78.31668F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "寄";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(52.91667F, 496.14F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(76.2F, 78.31668F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "收";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(73.68333F, 177.3768F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(650.6666F, 94.3967F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "740-405-07  000";
            // 
            // xrLine11
            // 
            this.xrLine11.BorderColor = System.Drawing.Color.Gray;
            this.xrLine11.Dpi = 254F;
            this.xrLine11.LineWidth = 3;
            this.xrLine11.LocationFloat = new DevExpress.Utils.PointFloat(40.21667F, 1131.139F);
            this.xrLine11.Name = "xrLine11";
            this.xrLine11.SizeF = new System.Drawing.SizeF(713.7834F, 5F);
            this.xrLine11.StylePriority.UseBorderColor = false;
            // 
            // xrLine8
            // 
            this.xrLine8.BorderColor = System.Drawing.Color.Gray;
            this.xrLine8.Dpi = 254F;
            this.xrLine8.LineWidth = 3;
            this.xrLine8.LocationFloat = new DevExpress.Utils.PointFloat(24.99999F, 798.8235F);
            this.xrLine8.Name = "xrLine8";
            this.xrLine8.SizeF = new System.Drawing.SizeF(729.0001F, 13.97003F);
            this.xrLine8.StylePriority.UseBorderColor = false;
            // 
            // xrLine7
            // 
            this.xrLine7.BorderColor = System.Drawing.Color.Gray;
            this.xrLine7.Dpi = 254F;
            this.xrLine7.LineWidth = 3;
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(25.80023F, 714.1564F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(728.1998F, 7.619934F);
            this.xrLine7.StylePriority.UseBorderColor = false;
            // 
            // xrLine5
            // 
            this.xrLine5.BorderColor = System.Drawing.Color.Gray;
            this.xrLine5.Dpi = 254F;
            this.xrLine5.LineWidth = 3;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(25.80023F, 602.3966F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(728.1998F, 19.05017F);
            this.xrLine5.StylePriority.UseBorderColor = false;
            // 
            // xrLine3
            // 
            this.xrLine3.BorderColor = System.Drawing.Color.Gray;
            this.xrLine3.Dpi = 254F;
            this.xrLine3.LineWidth = 3;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(25.80023F, 470.74F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(728.1998F, 7.116638F);
            this.xrLine3.StylePriority.UseBorderColor = false;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderColor = System.Drawing.Color.Gray;
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(25.80023F, 271.7735F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(728.1998F, 5F);
            this.xrLine2.StylePriority.UseBorderColor = false;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderColor = System.Drawing.Color.Gray;
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(25.80023F, 169.7568F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(713.7834F, 7.62001F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.BarCodeOrientation = DevExpress.XtraPrinting.BarCode.BarCodeOrientation.UpsideDown;
            this.xrBarCode1.Dpi = 254F;
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(78.33353F, 289.9767F);
            this.xrBarCode1.Module = 5.08F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(650.6666F, 160.02F);
            this.xrBarCode1.Symbology = code128Generator1;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Print.Model.PrintModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // Express
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(0, 1, 0, 0);
            this.PageHeight = 1300;
            this.PageWidth = 756;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "17.1";
            this.Watermark.Font = new System.Drawing.Font("宋体", 54F, System.Drawing.FontStyle.Bold);
            this.Watermark.ForeColor = System.Drawing.Color.Black;
            this.Watermark.Text = "405";
            this.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal;
            this.Watermark.TextTransparency = 226;
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
