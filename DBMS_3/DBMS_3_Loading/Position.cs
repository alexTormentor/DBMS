namespace DBMS_3_Loading;

public class Status
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Mech3> Mech3 { get; set; } = new();
}