namespace YourNamespace.Models
{
    public class Order
    {
        public int OrderId { get; set; }  // Primary Key
        public int UserId { get; set; }   // Foreign Key (links to Users table)
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
       
    }
}
