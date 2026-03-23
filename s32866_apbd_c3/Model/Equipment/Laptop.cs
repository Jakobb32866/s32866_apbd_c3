namespace s32866_apbd_c3.Model.Equipment;

public class Laptop : Equipment
{
    public int RamGB { set; get; }
    public OperatingSystem OperatingSystem { set; get; }

    public Laptop(string name, int ramGb, OperatingSystem operatingSystem) : base(name)
    {
        RamGB = ramGb;
        OperatingSystem = operatingSystem;
    }
}