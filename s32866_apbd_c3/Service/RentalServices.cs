using s32866_apbd_c3.Config;
using s32866_apbd_c3.Model.Equipment;
using s32866_apbd_c3.Model.Rental;
using s32866_apbd_c3.Model.User;

namespace s32866_apbd_c3.Service;

public class RentalServices
{
    public static void Rent(int userId, int equipmentId)
    {
        //Check if user/equipment exists
        User user = GlobalState.Users.Find(u => u.Identificator == userId);
        Equipment equipment = GlobalState.Equipments.Find(e => e.Identificator == equipmentId);
        if (user == null)
        {
            //TODO!!! THROW UI ERR
            return;
        }
        
        if (equipment == null)
        {
            //TODO!!! THROW UI ERR
            return;
        }

        if (equipment.Avaiability == EquipmentStatus.Rented)
        {
            //TODO!!! THROW UI ERR
            return;
        }
        
        if (equipment.Avaiability == EquipmentStatus.inService)
        {
            //TODO!!! THROW UI ERR
            return;
        }

        if (IsOverLimit(user))
        {
            //TODO!!! THROW UI ERR
            return;
        }
        
        GlobalState.Rentals.Add(new Rental(user, equipment));
    }

    public static void Return(int equipmentId)
    {
        Equipment equipment = GlobalState.Equipments.Find(e => e.Identificator == equipmentId);
        if (equipment == null)
        {
            //TODO!!! THROW UI ERR
            return;
        }
        
        foreach (Rental r in GlobalState.Rentals)
        {
            if (!r.Device.Equals(equipment) && !r.returnedDay.Equals(null))
            {
                r.Return();
                //TODO!! THROW UI FEE
            }
        }
    }
    

    public static string GenerateReport()
    {
        int totalEquipment = GlobalState.Equipments.Count;
        int availableEquipment = GlobalState.Equipments.Count(e => e.Avaiability == EquipmentStatus.Available);
        int activeRentals = GlobalState.Rentals.Count(r => r.returnedDay == 0);
        int overdueRentals = GlobalState.Rentals.Count(r => 
            r.returnedDay == 0 && GlobalSettings.CurrentDay > r.returnDay);
        int totalFees = GlobalState.Rentals.Sum(r => r.LateFee);

        return $"""
                ===== RAPORT WYPOŻYCZALNI =====
                Dzień systemu:        {GlobalSettings.CurrentDay}

                Sprzęt:
                  Łącznie:            {totalEquipment}
                  Dostępny:           {availableEquipment}
                  Niedostępny:        {totalEquipment - availableEquipment}

                Wypożyczenia:
                  Aktywne:            {activeRentals}
                  Przeterminowane:    {overdueRentals}
                  Łączne kary (PLN):  {totalFees}
                ==============================
                """;
    }


    private static bool IsOverLimit(User user)
    {
        if (user.UserType == UserType.Student)
        {
            if (CurrentRentals(user) >= GlobalSettings.StudentMaxRentals)
            {
                return true;
            }

            return false;
        }

        else
        {
            if (CurrentRentals(user) >= GlobalSettings.EmployeeMaxRentals)
            {
                return true;
            }

            return false;
        }
    }

    private static int CurrentRentals(User user)
    {
        int currentRentals = 0;

        foreach (Rental r in GlobalState.Rentals)
        {
            if (r.Renter.Equals(user))
            {
                currentRentals++;
            }
        }

        return currentRentals;
    }
}