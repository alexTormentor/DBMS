namespace DBMS_3;

public class MechDifficult
{
    public int PilotID { get; set; }
    public Pilot3 Pilot { get; set; }
 
    public int TypeID { get; set; }
    public Type3 Type { get; set; }
     
    public System.DateTime TestDate { get; set; }
}