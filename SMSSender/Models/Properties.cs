namespace SMSSender.Models;

public class Properties
{
    public Products Product { get; set; }
    public decimal Price { get; set; }
    public string Phone { get; set; }
    public ushort Diapason { get; set; }
    
}
public enum Products
{
    Smartphone=0,
    Computer=1,
    Television=2
}