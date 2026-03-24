using System.Text;
using s32866_apbd_c3.Config;
using s32866_apbd_c3.Model.Equipment;
using s32866_apbd_c3.Model.Rental;
using s32866_apbd_c3.Model.User;

namespace s32866_apbd_c3.Service;

public class UserServices
{
    public static void AddNewStudent(string name, string surname)
    {
        GlobalState.Users.Add(new User(name, surname, UserType.Student));
    }

    public static void AddNewEmployee(string name, string surname)
    {
        GlobalState.Users.Add(new User(name, surname, UserType.Employee));
    }

    public static string ShowUserList()
    {
        StringBuilder result = new StringBuilder();
        foreach (User u in GlobalState.Users)
            {
                result.Append("Id: " + u.Identificator + " Name: " + u.Name + " Surname: " + u.Surname + "\n");
            }
        return result.ToString();
    }

    public static string ShowActiveUserRentals(int userId)
    {
        StringBuilder result = new StringBuilder();
        foreach (Rental r in GlobalState.Rentals)
        {
            if (r.returnedDay == null)
            {
                result.Append("Device: " + r.Device + "Return day: " + r.returnDay + " Fee: " + r.LateFee + "\n");
            }
        }
        return result.ToString();
    }

    public static string ShowOverdueUserRentals(int userId)
    {
        StringBuilder result = new StringBuilder();
        foreach (Rental r in GlobalState.Rentals)
        {
            if (r.returnDay < GlobalSettings.CurrentDay)
            {
                result.Append("Device: " + r.Device + "Return day: " + r.returnDay + " Fee: " + r.LateFee + "\n");
            }
        }
        return result.ToString();
    }
}