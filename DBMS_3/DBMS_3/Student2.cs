namespace DBMS_3;

public class Pilot2
{
    public int Id { get; set; }
    public string Pilot { get; set; }
    public List<Type2> Type { get; set; } = new List<Type2>();
    public List<Testing> Testing { get; set; } = new List<Testing>();
}