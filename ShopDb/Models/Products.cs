
namespace ShopDb.Models
{
    public partial class Products
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public int Categoryid { get; set; }
        public decimal Unitprice { get; set; }
        public bool Discontinued { get; set; }

        public virtual Categories Category { get; set; }
    }
}