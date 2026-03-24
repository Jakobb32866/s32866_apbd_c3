using s32866_apbd_c3.Config;
using s32866_apbd_c3.Model.Equipment;
using s32866_apbd_c3.Service;

namespace s32866_apbd_c3.UI;

public static class UI
{
    public static void run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n===== WYPOŻYCZALNIA =====");
            Console.WriteLine("1. Pokaż sprzęt");
            Console.WriteLine("2. Pokaż dostępny sprzęt");
            Console.WriteLine("3. Dodaj laptop");
            Console.WriteLine("4. Dodaj drukarkę");
            Console.WriteLine("5. Dodaj serwer");
            Console.WriteLine("6. Dodaj studenta");
            Console.WriteLine("7. Dodaj pracownika");
            Console.WriteLine("8. Wypożycz sprzęt");
            Console.WriteLine("9. Zwróć sprzęt");
            Console.WriteLine("10. Wyślij sprzęt do serwisu");
            Console.WriteLine("11. Odbierz sprzęt z serwisu");
            Console.WriteLine("12. Pokaż użytkowników");
            Console.WriteLine("13. Pokaż wypożyczenia użytkownika");
            Console.WriteLine("14. Pokaż przeterminowane wypożyczenia");
            Console.WriteLine("15. Następny dzień");
            Console.WriteLine("16. Raport");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine(EquipmentServices.ShowEquipmentList());
                    break;
                case "2":
                    Console.WriteLine(EquipmentServices.ShowAvailableEqupmentList());
                    break;
                case "3":
                    Console.Write("Nazwa: ");
                    string laptopName = Console.ReadLine();
                    Console.Write("RAM (GB): ");
                    int ram = int.Parse(Console.ReadLine());
                    Console.WriteLine("System: 1=Windows, 2=Linux, 3=MacOS");
                    DeviceOperatingSystem os = Console.ReadLine() switch
                    {
                        "1" => DeviceOperatingSystem.Windows,
                        "2" => DeviceOperatingSystem.Linux,
                        "3" => DeviceOperatingSystem.MacOS,
                        _ => DeviceOperatingSystem.Windows
                    };
                    EquipmentServices.AddNewLaptop(laptopName, ram, os);
                    Console.WriteLine("Dodano laptopa.");
                    break;
                case "4":
                    Console.Write("Nazwa: ");
                    string printerName = Console.ReadLine();
                    Console.Write("Kolor? (t/n): ");
                    bool isColor = Console.ReadLine() == "t";
                    Console.Write("DPI: ");
                    int dpi = int.Parse(Console.ReadLine());
                    EquipmentServices.AddNewPrinter(printerName, isColor, dpi);
                    Console.WriteLine("Dodano drukarkę.");
                    break;
                case "5":
                    Console.Write("Nazwa: ");
                    string serverName = Console.ReadLine();
                    Console.Write("Sloty RAM: ");
                    int ramSlots = int.Parse(Console.ReadLine());
                    Console.Write("Storage (GB): ");
                    int storage = int.Parse(Console.ReadLine());
                    EquipmentServices.AddNewServer(serverName, ramSlots, storage);
                    Console.WriteLine("Dodano serwer.");
                    break;
                case "6":
                    Console.Write("Imię: ");
                    string sName = Console.ReadLine();
                    Console.Write("Nazwisko: ");
                    string sSurname = Console.ReadLine();
                    UserServices.AddNewStudent(sName, sSurname);
                    Console.WriteLine("Dodano studenta.");
                    break;
                case "7":
                    Console.Write("Imię: ");
                    string eName = Console.ReadLine();
                    Console.Write("Nazwisko: ");
                    string eSurname = Console.ReadLine();
                    UserServices.AddNewEmployee(eName, eSurname);
                    Console.WriteLine("Dodano pracownika.");
                    break;
                case "8":
                    Console.Write("ID użytkownika: ");
                    int userId = int.Parse(Console.ReadLine());
                    Console.Write("ID sprzętu: ");
                    int equipId = int.Parse(Console.ReadLine());
                    RentalServices.Rent(userId, equipId);
                    break;
                case "9":
                    Console.Write("ID sprzętu: ");
                    RentalServices.Return(int.Parse(Console.ReadLine()));
                    break;
                case "10":
                    Console.Write("ID sprzętu: ");
                    EquipmentServices.SendEquipmentToService(int.Parse(Console.ReadLine()));
                    break;
                case "11":
                    Console.Write("ID sprzętu: ");
                    EquipmentServices.GetEquipmentFromService(int.Parse(Console.ReadLine()));
                    break;
                case "12":
                    Console.WriteLine(UserServices.ShowUserList());
                    break;
                case "13":
                    Console.Write("ID użytkownika: ");
                    Console.WriteLine(UserServices.ShowActiveUserRentals(int.Parse(Console.ReadLine())));
                    break;
                case "14":
                    Console.WriteLine(UserServices.ShowOverdueUserRentals());
                    break;
                case "15":
                    GlobalSettings.NextDay();
                    Console.WriteLine($"Dzień: {GlobalSettings.CurrentDay}");
                    break;
                case "16":
                    Console.WriteLine(RentalServices.GenerateReport());
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }
}