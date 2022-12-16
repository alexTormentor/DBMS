namespace DBMS_3_Requests;

public class Mech
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
 
    public int CompanyId { get; set; }
    public Engine? Engine { get; set; }
}