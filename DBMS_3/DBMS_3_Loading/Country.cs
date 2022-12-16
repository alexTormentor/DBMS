namespace DBMS_3_Loading;

public class MechCore
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Corpus2> Corpus { get; set; } = new();
}