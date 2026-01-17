using komis_samochodowy;

class Program
{
    static void Main(string[] args)
    {
        CarDealer myKomis = new CarDealer();
        myKomis.LoadFromFile();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- SYSTEM OBSŁUGI KOMISU ---");
            Console.WriteLine("1. Dodaj Samochód Osobowy");
            Console.WriteLine("2. Dodaj Ciężarówkę");
            Console.WriteLine("3. Wyświetl Wszystkie Pojazdy");
            Console.WriteLine("4. Usuń Pojazd");
            Console.WriteLine("5. Modyfikuj Cenę Pojazdu");
            Console.WriteLine("6. Zapisz do Pliku (JSON)");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Marka: "); string brandP = Console.ReadLine();
                    Console.Write("Model: "); string modelP = Console.ReadLine();
                    
                    int yearP;
                    Console.Write("Rok produkcji: ");
                    while (!int.TryParse(Console.ReadLine(), out yearP)) Console.Write("Błędny rok, spróbuj ponownie: ");
                    
                    decimal priceP;
                    Console.Write("Cena: ");
                    while (!decimal.TryParse(Console.ReadLine(), out priceP)) Console.Write("Błędna cena, spróbuj ponownie: ");
                    
                    int seats;
                    Console.Write("Liczba miejsc: ");
                    while (!int.TryParse(Console.ReadLine(), out seats)) Console.Write("Błędna liczba, spróbuj ponownie: ");
            
                    myKomis.AddVehicle(new PassengerCar(brandP, modelP, yearP, priceP, seats));
                    Console.WriteLine("Samochód osobowy dodany!");
                    break;

                case "2":
                    Console.Write("Marka: "); string brandT = Console.ReadLine();
                    Console.Write("Model: "); string modelT = Console.ReadLine();
                    
                    int yearT;
                    Console.Write("Rok produkcji: ");
                    while (!int.TryParse(Console.ReadLine(), out yearT)) Console.Write("Błędny rok: ");
                    
                    decimal priceT;
                    Console.Write("Cena: ");
                    while (!decimal.TryParse(Console.ReadLine(), out priceT)) Console.Write("Błędna cena: ");
                    
                    double capacity;
                    Console.Write("Ładowność (w tonach): ");
                    while (!double.TryParse(Console.ReadLine(), out capacity)) Console.Write("Błędna ładowność: ");
                    
                    myKomis.AddVehicle(new Truck(brandT, modelT, yearT, priceT, capacity));
                    Console.WriteLine("Ciężarówka dodana!");
                    break;

                case "3":
                    Console.WriteLine("\n--- LISTA POJAZDÓW W KOMISIE ---");
                    myKomis.ShowVehicles();
                    break;

                case "4":
                    myKomis.ShowVehicles();
                    Console.Write("Podaj numer pojazdu do usunięcia: ");
                    if (int.TryParse(Console.ReadLine(), out int removeIdx))
                    {
                        myKomis.RemoveVehicle(removeIdx - 1);
                        Console.WriteLine("Operacja wykonana.");
                    }
                    break;

                case "5":
                    myKomis.ShowVehicles();
                    Console.Write("Podaj numer pojazdu do zmiany ceny: ");
                    if (int.TryParse(Console.ReadLine(), out int editIdx))
                    {
                        Console.Write("Podaj nową cenę: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                        {
                            myKomis.UpdatePrice(editIdx - 1, newPrice);
                            Console.WriteLine("Cena została zaktualizowana.");
                        }
                    }
                    break;

                case "6":
                    myKomis.SaveToFile();
                    Console.WriteLine("Dane zostały pomyślnie zapisane.");
                    break;

                case "0":
                    isRunning = false;
                    Console.WriteLine("Zamykanie programu...");
                    break;

                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}