namespace s32866_apbd_c3.Model.Equipment;

public class Laptop : Equipment
{
    public int RamGB { set; get; }
    public DeviceOperatingSystem DeviceOperatingSystem { set; get; }

    public Laptop(string name, int ramGb, DeviceOperatingSystem deviceOperatingSystem) : base(name)
    {
        RamGB = ramGb;
        DeviceOperatingSystem = deviceOperatingSystem;
    }
}