namespace DBMS_3;

public class Type2
{
    public int Id { get; set; }
    public string TypeMech { get; set; }
    public List<Pilot2> Pilot { get; set; }= new List<Pilot2>();
    public List<Testing> Testing { get; set; } = new List<Testing>();
}