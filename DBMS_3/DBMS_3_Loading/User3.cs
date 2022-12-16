namespace DBMS_3_Loading;

public class Mech3
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public int? CompanyId { get; set; }
    public Corpus3? Corpus3 { get; set; }
    public int? PositionId { get; set; }
    public Status? Status { get; set; }
}