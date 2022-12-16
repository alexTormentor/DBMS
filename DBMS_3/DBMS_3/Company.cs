namespace DBMS_3;

public class Corporation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Mech2> Mech { get; set; } = new List<Mech2>(); // сотрудники компании
}