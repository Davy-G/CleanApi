namespace Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public Decimal Price { get; set; }
    
    public int Quantity { get; set; }
    
}