namespace Domain.Entities;


public sealed class Person
{
    public long id { get; set; }

    public string name { get; set; } = default!;
    
    public string surname { get; set; } = default!;
    
    public string address { get; set; } = default!;
    
    public string legal_address { get; set; } = default!;
}