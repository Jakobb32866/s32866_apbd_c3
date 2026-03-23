using s32866_apbd_c3.Model.Equipment;
using s32866_apbd_c3.Model.Rental;
using s32866_apbd_c3.Model.User;

namespace s32866_apbd_c3.Config;

public class GlobalState
{
    public List<User> Users = new List<User>();
    public List<Equipment> Equipments = new List<Equipment>();
    public List<Rental> Rentals = new List<Rental>();
}