namespace Backend.Models;

public class PlayerModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ImageLink { get; set; }

    public string Club { get; set; }

    public string Birthday { get; set; }

    public string BirthPlace { get; set; }

    public int Weight { get; set; }

    public double Height { get; set; }

    public string Description { get; set; }

    public PositionModel Position { get; set; }

    public PlayerModel(int id, string name, string imageLink, string club, string birthday, string birthPlace, int weight, double height, string description, PositionModel position)
    {
        Id = id;
        Name = name;
        ImageLink = imageLink;
        Club = club;
        Birthday = birthday;
        BirthPlace = birthPlace;
        Weight = weight;
        Height = height;
        Description = description;
        Position = position;
    }

    public PlayerModel(PlayerEntity player)
    {
        Id = player.Id;
        Name = player.Name;
        ImageLink = player.ImageLink;
        Club = player.Club;
        Birthday = player.Birthday;
        BirthPlace = player.BirthPlace;
        Weight = player.Weight;
        Height = player.Height;
        Description = player.Description;
        Position = new PositionModel(player.Position);
    }

    public PlayerEntity ToEntity()
    {
        return new PlayerEntity
        {
            Id = Id,
            Name = Name,
            ImageLink = ImageLink,
            Club = Club,
            Birthday = Birthday,
            BirthPlace = BirthPlace,
            Weight = Weight,
            Height = Height,
            Description = Description,
            Position = Position.ToEntity(),
        };
    }

    public void ToEntity(PlayerEntity player)
    {
        player.Id = Id;
        player.Name = Name;
        player.ImageLink = ImageLink;
        player.Club = Club;
        player.Birthday = Birthday;
        player.BirthPlace = BirthPlace;
        player.Weight = Weight;
        player.Height = Height;
        player.Description = Description;
        player.Position = Position.ToEntity();
    }

    public PlayerModel()
    {
    }
}
