using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("georgians")]
[PrimaryKey("num")]
public class User
{
    [Column("num")]
    public int Id { get; set; }
    [Column("num")]
    public TYPE Type { get; set; }
    public TYPE Type { get; set; }
    public TYPE Type { get; set; }
    public TYPE Type { get; set; }
    public TYPE Type { get; set; }
    public TYPE Type { get; set; }
    public TYPE Type { get; set; }
    public TYPE Type { get; set; }
}