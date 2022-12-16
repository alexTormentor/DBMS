public class Mech
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string SerialID { get; set; }
  
    public MechSystem MechSys { get; set; }
}