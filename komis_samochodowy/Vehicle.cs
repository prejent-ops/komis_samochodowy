using System.Text.Json.Serialization;

namespace komis_samochodowy;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(PassengerCar), "passenger")]
[JsonDerivedType(typeof(Truck), "truck")]
public abstract class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    protected Vehicle(string brand, string model, int year, decimal price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }

    public abstract string GetInfo();
}