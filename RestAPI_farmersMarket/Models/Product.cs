namespace RestAPI_farmersMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public List<Product>? products { get; set; }
    }
}
