using System.Text.Json;

namespace komis_samochodowy;

public class CarDealer
{
    private List<Vehicle> vehicles = new List<Vehicle>();
    private const string filename = "komis.json";

    public void AddVehicle(Vehicle v) => vehicles.Add(v);

    public void ShowVehicles()
    {
        if (vehicles.Count == 0) 
        { 
            Console.WriteLine("Komis jest pusty."); 
            return; 
        }
        for (int i = 0; i < vehicles.Count; i++)
            Console.WriteLine($"{i + 1}. {vehicles[i].GetInfo()}");
    }

    public void RemoveVehicle(int index)
    {
        if (index >= 0 && index < vehicles.Count) 
            vehicles.RemoveAt(index);
        else
            Console.WriteLine("Nieprawidłowy numer pojazdu.");
    }

    public void UpdatePrice(int index, decimal newPrice)
    {
        if (index >= 0 && index < vehicles.Count) 
            vehicles[index].Price = newPrice;
        else
            Console.WriteLine("Nieprawidłowy numer pojazdu.");
    }

    public void SaveToFile()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(vehicles, options);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile()
    {
        try
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas ładowania bazy: {ex.Message}");
            vehicles = new List<Vehicle>();
        }
    }
}