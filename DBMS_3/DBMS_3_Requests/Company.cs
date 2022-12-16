namespace DBMS_3_Requests;

public class Engine
{
    public int Id { get; set; }
    public string? Name { get; set; }
 
    public List<Mech> Mech { get; set; } = new();
}