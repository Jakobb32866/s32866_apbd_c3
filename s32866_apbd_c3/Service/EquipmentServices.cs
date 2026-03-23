using System.Text;
using s32866_apbd_c3.Config;
using s32866_apbd_c3.Model.Equipment;

namespace s32866_apbd_c3.Service;

public class EquipmentServices
{
    public static void AddNewLaptop(string name, int ram, DeviceOperatingSystem operatingSystem)
    {
        GlobalState.Equipments.Add(new Laptop(name, ram, operatingSystem));
    }

    public static void AddNewPrinter(string name, bool isColorPrint, int dpi)
    {
        GlobalState.Equipments.Add(new Printer(name, isColorPrint, dpi));
    }

    public static void AddNewServer(string name, int ramSlots, int storageGb)
    {
        GlobalState.Equipments.Add(new Server(name, ramSlots, storageGb));
    }

    public static string ShowEquipmentList()
    {
        StringBuilder result = new StringBuilder();
        foreach (Equipment e in GlobalState.Equipments)
        {
            result.Append("Id:" + e.Identificator + " Type: " + e.GetType() + " Name: " + e.Name + " Available: " +
                          e.Available + "\n");
        }
        return result.ToString();
    }

    public static string ShowAvailableEqupmentList()
    {
        StringBuilder result = new StringBuilder();
        foreach (Equipment e in GlobalState.Equipments)
            if (e.Available)
            {
                {
                    result.Append("Id:" + e.Identificator + " Type: " + e.GetType() + " Name: " + e.Name + " Available: " +
                                  e.Available + "\n");
                }
            }
        return result.ToString();
    }
}