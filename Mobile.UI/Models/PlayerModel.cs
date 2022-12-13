﻿namespace Mobile.Models;

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

    public PlayerModel()
    {
    }

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
}