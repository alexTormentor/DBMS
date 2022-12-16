namespace DBMS_3;

public class Pilot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Type> Type { get; set; } = new List<Type>();
}