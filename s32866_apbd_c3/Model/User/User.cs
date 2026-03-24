namespace s32866_apbd_c3.Model.User;

public class User
{
    private static int IdentificatorSetter = 0;
    
    public int Identificator { get; }
    public string Name { get; }
    public string Surname { get; }
    public UserType UserType { get; }

    public User(string name, string surname, UserType type)
    {
        Identificator = SetIdentyficator();
        Name = name;
        Surname = surname;
        UserType = type;
    }
    
    private int SetIdentyficator()
    {
        IdentificatorSetter++;
        return IdentificatorSetter;
    }
}