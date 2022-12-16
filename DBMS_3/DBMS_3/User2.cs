namespace DBMS_3;

public class Mech2
{
    public int Id { get; set; }
    public string Model { get; set; }
 
    public int CorpID { get; set; }
    public Corporation Corporations { get; set; }  // компания пользователя
}