namespace DBMS_3;

public class Type3
{
    public int Id { get; set; }
    public string TypeMech { get; set; }
    public List<MechDifficult> MechDifficult { get; set; }
     
    public Type3()
    {
        MechDifficult = new List<MechDifficult>();
    }
}