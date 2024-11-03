namespace WebAppFrontend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Constructor to initialize all properties
        public Order()
        {
            // คอนสตรัคเตอร์ที่ไม่มีพารามิเตอร์
        }

        // คอนสตรัคเตอร์ที่มีพารามิเตอร์
        public Order(int id, DateTime orderDate, string region, string city, string category, string product, int quantity, decimal unitPrice)
        {
            Id = id;
            OrderDate = orderDate;
            Region = region;
            City = city;
            Category = category;
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = quantity * unitPrice; // คำนวณ TotalPrice
        }
    }
}
