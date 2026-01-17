namespace komis_samochodowy;

public class PassengerCar : Vehicle
{
    public int NumberOfSeats { get; set; }

    public PassengerCar(string brand, string model, int year, decimal price, int numberOfSeats)
        : base(brand, model, year, price)
    {
        NumberOfSeats = numberOfSeats;
    }

    public override string GetInfo() => 
        $"[Osobowy] {Brand} {Model}, Rok: {Year}, Cena: {Price:N2} PLN, Miejsca: {NumberOfSeats}";
}