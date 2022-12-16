namespace DBMS_3_Loading;

public class Corpus
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Mech> Mech { get; set; } = new();
}