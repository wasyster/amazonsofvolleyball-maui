namespace Backend.Models;

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

    public PositionModel(PositionEntity entity)
    { 
        Id = entity.Id;
        Name = entity.Name;
    }

    public PositionEntity ToEntity()
    {
        return new PositionEntity
        {
            Id = Id,
            Name = Name
        };
    }

    public void ToEntity(PositionEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
    }
}
