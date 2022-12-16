namespace DBMS_3_Requests;

public class Corpus2
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CountryId { get; set; }
    public Type? Type { get; set; }
    public List<Mech2> Mech { get; set; } = new();
}