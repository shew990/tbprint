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
public class Express2 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRBarCode xrBarCode3;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLine xrLine15;
    private XRLine xrLine4;
    private XRBarCode xrBarCode2;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLine xrLine14;
    private XRLine xrLine11;
    private XRLine xrLine10;
    private XRLine xrLine9;
    private XRLine xrLine8;
    private XRLine xrLine7;
    private XRLine xrLine6;
    private XRLine xrLine5;
    private XRLine xrLine3;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRBarCode xrBarCode1;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private XRLabel xrLabel26;
    private XRLabel xrLabel25;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    private XRLabel xrLabel22;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRBarCode xrBarCode4;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Express2()
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
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator3 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator2 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine8 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine9 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine10 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine11 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine14 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode2 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine15 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode3 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrBarCode4 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel26,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrBarCode4,
            this.xrBarCode3,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLine15,
            this.xrLine4,
            this.xrBarCode2,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLine14,
            this.xrLine11,
            this.xrLine10,
            this.xrLine9,
            this.xrLine8,
            this.xrLine7,
            this.xrLine6,
            this.xrLine5,
            this.xrLine3,
            this.xrLine2,
            this.xrLine1,
            this.xrBarCode1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 1800F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            // xrLine1
            // 
            this.xrLine1.BorderColor = System.Drawing.Color.Gray;
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 146.4734F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(997F, 7.62001F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Dpi = 254F;
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(665.0833F, 309.0267F);
            this.xrBarCode1.Module = 5.08F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(292.1001F, 58.41998F);
            this.xrBarCode1.Symbology = code128Generator3;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderColor = System.Drawing.Color.Gray;
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 271.7733F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(997F, 9.736664F);
            this.xrLine2.StylePriority.UseBorderColor = false;
            // 
            // xrLine3
            // 
            this.xrLine3.BorderColor = System.Drawing.Color.Gray;
            this.xrLine3.Dpi = 254F;
            this.xrLine3.LineWidth = 3;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 379.7233F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(997F, 5F);
            this.xrLine3.StylePriority.UseBorderColor = false;
            // 
            // xrLine5
            // 
            this.xrLine5.BorderColor = System.Drawing.Color.Gray;
            this.xrLine5.Dpi = 254F;
            this.xrLine5.LineWidth = 3;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 542.7067F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(997F, 13.12335F);
            this.xrLine5.StylePriority.UseBorderColor = false;
            // 
            // xrLine6
            // 
            this.xrLine6.BorderColor = System.Drawing.Color.Gray;
            this.xrLine6.Dpi = 254F;
            this.xrLine6.LineWidth = 3;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(3.229777E-05F, 672.67F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(997.0001F, 15.23993F);
            this.xrLine6.StylePriority.UseBorderColor = false;
            // 
            // xrLine7
            // 
            this.xrLine7.BorderColor = System.Drawing.Color.Gray;
            this.xrLine7.Dpi = 254F;
            this.xrLine7.LineWidth = 3;
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 872.9067F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(997F, 22.43658F);
            this.xrLine7.StylePriority.UseBorderColor = false;
            // 
            // xrLine8
            // 
            this.xrLine8.BorderColor = System.Drawing.Color.Gray;
            this.xrLine8.Dpi = 254F;
            this.xrLine8.LineWidth = 3;
            this.xrLine8.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 1076.107F);
            this.xrLine8.Name = "xrLine8";
            this.xrLine8.SizeF = new System.Drawing.SizeF(997F, 11.85339F);
            this.xrLine8.StylePriority.UseBorderColor = false;
            // 
            // xrLine9
            // 
            this.xrLine9.BorderColor = System.Drawing.Color.Gray;
            this.xrLine9.Dpi = 254F;
            this.xrLine9.LineWidth = 3;
            this.xrLine9.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 1169.24F);
            this.xrLine9.Name = "xrLine9";
            this.xrLine9.SizeF = new System.Drawing.SizeF(997F, 11.85339F);
            this.xrLine9.StylePriority.UseBorderColor = false;
            // 
            // xrLine10
            // 
            this.xrLine10.BorderColor = System.Drawing.Color.Gray;
            this.xrLine10.Dpi = 254F;
            this.xrLine10.LineWidth = 3;
            this.xrLine10.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 1281.423F);
            this.xrLine10.Name = "xrLine10";
            this.xrLine10.SizeF = new System.Drawing.SizeF(997F, 5F);
            this.xrLine10.StylePriority.UseBorderColor = false;
            // 
            // xrLine11
            // 
            this.xrLine11.BorderColor = System.Drawing.Color.Gray;
            this.xrLine11.Dpi = 254F;
            this.xrLine11.LineWidth = 3;
            this.xrLine11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1370.323F);
            this.xrLine11.Name = "xrLine11";
            this.xrLine11.SizeF = new System.Drawing.SizeF(997F, 5F);
            this.xrLine11.StylePriority.UseBorderColor = false;
            // 
            // xrLine14
            // 
            this.xrLine14.BorderColor = System.Drawing.Color.Gray;
            this.xrLine14.Dpi = 254F;
            this.xrLine14.LineWidth = 3;
            this.xrLine14.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 1668.773F);
            this.xrLine14.Name = "xrLine14";
            this.xrLine14.SizeF = new System.Drawing.SizeF(997F, 5F);
            this.xrLine14.StylePriority.UseBorderColor = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(24.99999F, 309.0267F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(254F, 58.42F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "区域件";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(24.99999F, 154.0934F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(947F, 117.68F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "411-405-07-001";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 441.1067F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(76.2F, 78.31668F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "收";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 577.8433F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(76.2F, 78.31668F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "寄";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(100.5667F, 396.6567F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(885.85F, 45.71994F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "区域件";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(100.5666F, 442.3766F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(885.85F, 100.33F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "区域件";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(100.5667F, 555.83F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(885.85F, 37.2533F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "区域件";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(100.5667F, 597.7401F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(885.85F, 74.92999F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "区域件";
            // 
            // xrBarCode2
            // 
            this.xrBarCode2.Dpi = 254F;
            this.xrBarCode2.LocationFloat = new DevExpress.Utils.PointFloat(100.5667F, 726.8567F);
            this.xrBarCode2.Module = 5.08F;
            this.xrBarCode2.Name = "xrBarCode2";
            this.xrBarCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.xrBarCode2.SizeF = new System.Drawing.SizeF(802.2167F, 124.8833F);
            this.xrBarCode2.Symbology = code128Generator2;
            // 
            // xrLine4
            // 
            this.xrLine4.BorderColor = System.Drawing.Color.Gray;
            this.xrLine4.Dpi = 254F;
            this.xrLine4.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine4.LineWidth = 3;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(193.7F, 883.49F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(10.63333F, 204.4701F);
            this.xrLine4.StylePriority.UseBorderColor = false;
            // 
            // xrLine15
            // 
            this.xrLine15.BorderColor = System.Drawing.Color.Gray;
            this.xrLine15.Dpi = 254F;
            this.xrLine15.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine15.LineWidth = 3;
            this.xrLine15.LocationFloat = new DevExpress.Utils.PointFloat(402.1667F, 883.49F);
            this.xrLine15.Name = "xrLine15";
            this.xrLine15.SizeF = new System.Drawing.SizeF(10.63333F, 204.4701F);
            this.xrLine15.StylePriority.UseBorderColor = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(412.8F, 895.3433F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(584.2F, 126.1533F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "快递描述收件人地址，收件人或者寄件人允许签收，视为描述：您的签字代表您已验收此包裹，并确认商品完好无损，没有划痕，没有破损等质量问题。";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(846.0833F, 1038.007F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(140.3334F, 38.09985F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "签收栏";
            // 
            // xrBarCode3
            // 
            this.xrBarCode3.Dpi = 254F;
            this.xrBarCode3.LocationFloat = new DevExpress.Utils.PointFloat(204.3333F, 895.3433F);
            this.xrBarCode3.Module = 5.08F;
            this.xrBarCode3.Name = "xrBarCode3";
            this.xrBarCode3.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.xrBarCode3.SizeF = new System.Drawing.SizeF(197.8333F, 180.7634F);
            this.xrBarCode3.Symbology = qrCodeGenerator1;
            // 
            // xrBarCode4
            // 
            this.xrBarCode4.Dpi = 254F;
            this.xrBarCode4.LocationFloat = new DevExpress.Utils.PointFloat(412.8F, 1113.36F);
            this.xrBarCode4.Module = 5.08F;
            this.xrBarCode4.Name = "xrBarCode4";
            this.xrBarCode4.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.xrBarCode4.SizeF = new System.Drawing.SizeF(539.775F, 55.88013F);
            this.xrBarCode4.Symbology = code128Generator1;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(111.1499F, 1181.093F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(885.85F, 43.60339F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "区域件";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(111.1501F, 1228.003F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(885.85F, 42.83643F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "区域件";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(111.1501F, 1286.423F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(885.85F, 41.56653F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "区域件";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(111.1501F, 1327.99F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(885.85F, 41.48669F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "区域件";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(10.58351F, 1286.423F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(76.2F, 78.31668F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "寄";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 254F;
            this.xrLabel16.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(10.58351F, 1192.523F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(76.2F, 78.31668F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "收";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 254F;
            this.xrLabel17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 1388.315F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(132.3167F, 43.60339F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "文件";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 254F;
            this.xrLabel18.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(846.0833F, 1614.798F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(132.3167F, 43.60339F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "已验视";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 254F;
            this.xrLabel19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(161.95F, 1687.823F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(592.6669F, 52.07007F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "区域件";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 254F;
            this.xrLabel20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(10.58351F, 1687.823F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(151.3665F, 52.07007F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "订单号：";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 254F;
            this.xrLabel21.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(770.4667F, 1756.397F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(207.9333F, 43.60339F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "-手机尾号-";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 254F;
            this.xrLabel22.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(770.4667F, 1673.773F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(207.9333F, 82.62366F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.Text = "0334";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 254F;
            this.xrLabel23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 895.3433F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(189.9168F, 34.71338F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "2018-12-20";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 254F;
            this.xrLabel24.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 930.0566F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(189.9168F, 34.71338F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "16:20:22";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 254F;
            this.xrLabel25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(3.783183F, 964.7701F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(158.1668F, 34.71338F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = " 打印时间";
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 254F;
            this.xrLabel26.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(3.783183F, 999.4835F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(189.9168F, 34.71338F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.Text = "数量：1";
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
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1800;
            this.PageWidth = 1000;
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
