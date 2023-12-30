using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products
{

    internal class Product: IProduct
    {
        private int idProduct;
        private string productName;
        private string serialNumber;
        private string brand;
        private DateTime manufacturingDate;
        private string category;
        private string subCategory;
        private string description;
        private float height;
        private float width;
        private float depth;
        private float weight;
        private string energyClass;
        private float power;
        private float energyConsumption;
        private string notes;
        private string barcode;



        private Image image;

        public Product()
        {

        }

        public int IdProduct
        {
            get { return idProduct; }
            set { idProduct = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    productName = value;
                }
                else
                {
                    throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
                }
            }
        }

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public DateTime ManufacturingDate
        {
            get { return manufacturingDate; }
            set { manufacturingDate = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string SubCategory
        {
            get { return subCategory; }
            set { subCategory = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string EnergyClass
        {
            get { return energyClass; }
            set { energyClass = value; }
        }

        public float Power
        {
            get { return power; }
            set { power = value; }
        }

        public float EnergyConsumption
        {
            get { return energyConsumption; }
            set { energyConsumption = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
    }

}
