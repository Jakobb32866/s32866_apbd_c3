namespace s32866_apbd_c3.Model;

public class Printer : Equipment
{
    private bool IsColorPrint { get; }
    private int DPI { get; }

    public Printer(string name, bool isColorPrint, int dpi) : base(name)
    {
        IsColorPrint = isColorPrint;
        DPI = dpi;
    }
}