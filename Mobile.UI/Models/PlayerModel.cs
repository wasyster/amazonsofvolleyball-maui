namespace Mobile.Models;

public class PlayerModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string LocalImageLink { get; set; }

    public string WebImageLink { get; set; }

    public string Club { get; set; }

    public string Birthday { get; set; }

    public string BirthPlace { get; set; }

    public int Weight { get; set; }

    public double Height { get; set; }

    public string Description { get; set; }

    public PositionModel Position { get; set; }

    public PlayerModel()
    {
    }

    public PlayerModel(int id, string name, string localImageLink, string webImageLink, string club, string birthday, string birthPlace, int weight, double height, string description, PositionModel position)
    {
        Id = id;
        Name = name;
        LocalImageLink = localImageLink;
        WebImageLink = webImageLink;
        Club = club;
        Birthday = birthday;
        BirthPlace = birthPlace;
        Weight = weight;
        Height = height;
        Description = description;
        Position = position;
    }
}
