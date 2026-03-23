namespace s32866_apbd_c3.Model;

public class Equipment
{
    private static int IdentificatorSetter = 0;
    
    protected int Identificator { get; }
    protected string Name { get; }
    protected bool Available { get; set; }

    protected Equipment(string name)
    {
        Identificator = SetIdentyficator();
        Name = name;
        Available = true;
    }

    private int SetIdentyficator()
    {
        IdentificatorSetter++;
        return IdentificatorSetter;
    }
}