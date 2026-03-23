using s32866_apbd_c3.Config;

namespace s32866_apbd_c3.Model.User;

public class Student : User
{
    public Student(string name, string surname) : base(name, surname, GlobalSettings.StudentMaxRentals)
    {
        
    }
}