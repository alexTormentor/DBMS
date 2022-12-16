namespace DBMS_3_Loading;

public class Corpus4
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual List<Mech4> Mech4 { get; set; } = new ();
}