namespace DBMS_3;

public class Type
{
    public int Id { get; set; }
    public string TypeMech { get; set; }
    public List<Pilot> Pilot { get; set; }= new List<Pilot>();
}