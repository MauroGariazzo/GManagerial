using System;
using System.Drawing;

public interface IProduct
{
    int IdProduct { get; set; }
    string ProductName { get; set; }
    string SerialNumber { get; set; }
    string Brand { get; set; }
    DateTime ManufacturingDate { get; set; }
    string Category { get; set; }
    string SubCategory { get; set; }
    string Description { get; set; }
    float Height { get; set; }
    float Width { get; set; }
    float Depth { get; set; }
    float Weight { get; set; }
    string EnergyClass { get; set; }
    float Power { get; set; }
    float EnergyConsumption { get; set; }
    string Notes { get; set; }
    string Barcode { get; set; }
    Image Image { get; set; }
}
