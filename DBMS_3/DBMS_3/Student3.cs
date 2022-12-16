namespace DBMS_3;

public class Pilot3
{
    public int Id { get; set; }
    public string PilotType { get; set; }
    public List<MechDifficult> MechDifficult { get; set; }
     
    public Pilot3()
    {
        MechDifficult = new List<MechDifficult>();
    }
}