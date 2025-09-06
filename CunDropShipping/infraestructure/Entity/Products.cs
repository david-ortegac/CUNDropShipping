using System.ComponentModel.DataAnnotations.Schema;

namespace CUNDropShipping.infraestructure.Entity;

[Table("Products")]
public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}