namespace Mobile.Models;

public class PositionModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public PositionModel()
    {
    }

    public PositionModel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
