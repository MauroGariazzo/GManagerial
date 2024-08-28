using System;
using System.Drawing;
using GManagerial.Products;
using GManagerial.Products.ChildForms;
using GManagerial;
using System.Collections.Generic;
using System.Net.Mail;
using System.Data.SqlTypes;

internal interface IProduct
{
    int ID { get; set; }
    string ProductName { get; set; }
    string SerialNumber { get; set; }
    string ManufacturingDate { get; set; }
    ICategory CategoryObj { get; set; }
    ISubCategory SubCategory { get; set; }
    string Description { get; set; }
    decimal? GetHeight { get; }
    void SetHeight(string value);
    decimal? GetWidth { get; }
    void SetWidth(string value);
    decimal? GetDepth { get; }
    void SetDepth(string value);
    decimal? GetWeight { get; }
    void SetWeight(string value);
    string EnergyClass { get; set; }
    decimal? GetPower { get; }
    void SetPower(string value);
    decimal? GetEnergyConsumption { get; }
    void SetEnergyConsumption(string value);
    string Notes { get; set; }
    string Barcode { get; set; }
    Image Image { get; set; }
    Image ResizedImage { get; set; }
    IBrand BrandP { get; set; }

    byte[] ConvertImageToArrayBytes();
    byte[] ConvertResizeImageToArrayBytes();
    //bool ConvertToDecimal(string value);
}
