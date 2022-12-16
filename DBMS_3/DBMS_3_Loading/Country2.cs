namespace DBMS_3_Loading;

public class Corporation2
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CapitalId { get; set; }
    public Weapon? Weapon { get; set; }  // столица страны
    public List<Corpus3> Corpus3 { get; set; } = new();
}