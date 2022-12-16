namespace DBMS_3_Loading;

public class Mech4
{
    public int Id { get; set; }
    public string? Model { get; set; }
 
    public int? CompanyId { get; set; }
    public virtual Corpus4? Corpus4 { get; set; }
}