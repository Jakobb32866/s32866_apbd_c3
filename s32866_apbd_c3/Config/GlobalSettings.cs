namespace s32866_apbd_c3.Config;

public static class GlobalSettings
{
    public static int CurrentDay { get; private set; } = 1;
    
    public static int StudentMaxRentals { get; private set; } = 2;
    public static int EmployeeMaxRentals { get; private set; } = 5;
    public static int RentalTime { get; private set; } = 7;
    public static int LateFeePerDay { get; private set; } = 10; //PLN


    public static void NextDay()
    {
        CurrentDay++;
    }
}