namespace DBMS_3_Loading;

public class Corpus3
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CountryId { get; set; }
    public Corporation2? Corporation2 { get; set; }
    public List<Mech3> Mech3 { get; set; } = new();
}