namespace Domain.Entities;


public sealed class Person
{
    public long Id { get; set; }

    public string Name { get; set; } = default!;
    
    public string Surname { get; set; } = default!;

    public DateOnly Reg_Dat { get; set; }
}