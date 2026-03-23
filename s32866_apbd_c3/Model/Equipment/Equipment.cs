namespace s32866_apbd_c3.Model.Equipment;

public abstract class Equipment
{
    private static int IdentificatorSetter = 0;
    
    public int Identificator { get; }
    public string Name { get; }
    public bool Available { get; set; }

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