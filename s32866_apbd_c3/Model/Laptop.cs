namespace s32866_apbd_c3.Model;

public class Laptop : Equipment
{
    private int RamGB { set; get; }
    private OperatingSystem OperatingSystem { set; get; }

    public Laptop(string name, int ramGb, OperatingSystem operatingSystem) : base(name)
    {
        RamGB = ramGb;
        OperatingSystem = operatingSystem;
    }
}