using s32866_apbd_c3.Config;

namespace s32866_apbd_c3.Model.Rental;

using s32866_apbd_c3.Model.User;
using s32866_apbd_c3.Model.Equipment;


public class Rental
{
    public int rentedDay { get; }
    public int returnDay { get; }
    public int returnedDay { get; private set; }
    public User Renter { get; }
    public Equipment Device { get; }
    public int LateFee { get; private set; }

    public Rental(User user, Equipment equipment)
    {
        rentedDay = GlobalSettings.CurrentDay;
        returnDay = rentedDay + GlobalSettings.RentalTime;
        Renter = user;
        Device = equipment;
        Device.Avaiability = EquipmentStatus.Rented;
    }

    public void Return()
    {
        Device.Avaiability = EquipmentStatus.Available;
        returnedDay = GlobalSettings.CurrentDay;
        if (returnedDay - returnDay > 0)
        {
            LateFee = GlobalSettings.LateFeePerDay * (returnedDay - returnDay);
            return;
        }
        
        LateFee = 0;
    }
}