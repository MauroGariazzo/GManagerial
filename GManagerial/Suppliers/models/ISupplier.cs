namespace GManagerial
{
    internal interface ISupplier
    {
        int ID { get; set; }
        string SupplierName { get; set; }
        string IdTax { get; set; }
        string Vat { get; set; }
        string RecipientCode { get; set; }
        string Region { get; set; }
        string Province { get; set; }
        string ProvinceSigle { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Telephone { get; set; }
        string Mobile { get; set; }
        string ZipCode { get; set; }
        string Email { get; set; }
        string Pec { get; set; }
        string Notes { get; set; }

    }
}
