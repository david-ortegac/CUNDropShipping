using System.ComponentModel.DataAnnotations.Schema;

namespace CUNDropShipping;

[Table("Products")]
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}