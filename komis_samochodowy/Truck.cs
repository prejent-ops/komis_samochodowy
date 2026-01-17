namespace komis_samochodowy;

public class Truck : Vehicle
{
    public double LoadCapacity { get; set; }

    public Truck(string brand, string model, int year, decimal price, double loadCapacity) 
        : base(brand, model, year, price)
    {
        LoadCapacity = loadCapacity;
    }
    
    public override string GetInfo() => 
        $"[Ciężarowy] {Brand} {Model}, Rok: {Year}, Cena: {Price:N2} PLN, Ładowność: {LoadCapacity} t";
}