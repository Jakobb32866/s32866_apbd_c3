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

        if (equipment.Available == false)
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
            if (!r.Device.Equals(equipment) || !r.returnedDay.Equals(null))
            {
                r.Return();
                //TODO!! THROW UI FEE
            }
        }
    }
    



    private static bool IsOverLimit(User user)
    {
        if (user.UserType == UserType.Student)
        {
            if (CurrentRentals(user) > GlobalSettings.StudentMaxRentals)
            {
                return true;
            }

            return false;
        }

        else
        {
            if (CurrentRentals(user) > GlobalSettings.EmployeeMaxRentals)
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