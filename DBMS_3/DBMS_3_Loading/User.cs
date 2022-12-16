namespace DBMS_3_Loading;

public class Mech
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? CompanyId { get; set; }
    public Corpus? Corpus { get; set; }
}