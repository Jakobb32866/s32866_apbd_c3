namespace s32866_apbd_c3.Model.Equipment;

public class Server : Equipment
{
    public int StorageGB { get; set; }
    public int RAMSlots { get; }

    public Server(string name, int ramSlots, int storageGb) : base(name)
    {
        StorageGB = storageGb;
        RAMSlots = ramSlots;
    }
}