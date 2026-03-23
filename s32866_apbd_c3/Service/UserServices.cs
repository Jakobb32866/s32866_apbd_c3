using s32866_apbd_c3.Config;
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
}