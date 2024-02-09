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
    DateTime? ManufacturingDate { get; set; }
    ICategory CategoryObj { get; set; }
    ISubCategory SubCategory { get; set; }
    string Description { get; set; }
    decimal? Height { get; set; }
    decimal? Width { get; set; }
    decimal? Depth { get; set; }
    decimal? Weight { get; set; }
    string EnergyClass { get; set; }
    decimal? Power { get; set; }
    decimal? EnergyConsumption { get; set; }
    string Notes { get; set; }
    string Barcode { get; set; }
    Image Image { get; set; }
    Image ResizedImage { get; set; }
    IBrand BrandP { get; set; }

    byte[] ConvertImageToArrayBytes();
    byte[] ConvertResizeImageToArrayBytes();

}
