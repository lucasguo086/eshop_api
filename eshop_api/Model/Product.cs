using System.ComponentModel.DataAnnotations;
namespace eshop_api.Model;

public class Product
{
    [Key] 
    public int Id { set; get; }
    public string Sku { set; get; }
    public string Name { set; get; }
    public float Price { set; get; }
    public string? ImageLink { set; get; }
    public string? Abv { set; get; }
    public string? Category { set; get; }
    public string? BottleSize { set; get; }
    public DateTime CollectionDate { set; get; }
}