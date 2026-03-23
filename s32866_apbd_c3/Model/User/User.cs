namespace s32866_apbd_c3.Model.User;

public abstract class User
{
    private static int IdentificatorSetter = 0;
    
    public int Identificator { get; }
    public string Name { get; }
    public string Surname { get; }
    public int MaxRentals { get; }

    protected User(string name, string surname, int maxRentals)
    {
        Identificator = SetIdentyficator();
        Name = name;
        Surname = surname;
        MaxRentals = maxRentals;
    }
    
    private int SetIdentyficator()
    {
        IdentificatorSetter++;
        return IdentificatorSetter;
    }
}