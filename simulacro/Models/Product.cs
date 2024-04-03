namespace simulacro.Models
{
    public class Product
        {
            public int Id { get;set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Int64 Price { get; set; }
            public Int64 Amount { get; set; }
            public string Address { get; set; }
            public Int64 Phone{ get; set; }
            public DateTime ExpirationDate { get; set; }
        }
    
}