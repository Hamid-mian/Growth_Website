namespace Growth_Website.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string? imagename { get; set; }
        public string? productName { get; set; }
        public int price { get; set; }
        public string? productType { get; set; }
        public string? customerName { get; set; }
        public int? customerId { get; set; } 

    }
}
