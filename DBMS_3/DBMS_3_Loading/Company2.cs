namespace DBMS_3_Loading;

public class Corpus2
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CountryId { get; set; }
    public MechCore? Core { get; set; }
    public List<Mech2> Mech { get; set; } = new();
}