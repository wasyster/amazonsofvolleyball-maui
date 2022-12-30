namespace Backend.Models;

public partial class PlayerModel : BaseViewModel
{
    private int id;
    private string name;
    private string localImageLink;
    private string webImageLink;
    private string club;
    private string birthday;
    private string birthPlace;
    private int weight;
    private double height;
    private string positionName;
    private int positionId;
    private string description;

    public int Id
    {
        get => this.id;
        set => SetProperty(ref this.id, value, true);
    }

    [Required]
    [StringLength(255)]
    [MinLength(2)]
    public string Name
    {
        get => this.name;
        set => SetProperty(ref this.name, value, true);
    }

    [StringLength(4096)]
    public string LocalImageLink
    {
        get => this.localImageLink;
        set => SetProperty(ref this.localImageLink, value, true);
    }

    [Required]
    [StringLength(4096)]
    public string WebImageLink
    {
        get => this.webImageLink;
        set => SetProperty(ref this.webImageLink, value, true);
    }

    [Required]
    [StringLength(255)]
    [MinLength(2)]
    public string Club
    {
        get => this.club;
        set => SetProperty(ref this.club, value, true);
    }

    [Required]
    [StringLength(32)]
    public string Birthday
    {
        get => this.birthday;
        set => SetProperty(ref this.birthday, value, true);
    }

    [Required]
    [StringLength(255)]
    public string BirthPlace
    {
        get => this.birthPlace;
        set => SetProperty(ref this.birthPlace, value, true);
    }

    [Required]
    [Range(0, 100)]
    public int Weight
    {
        get => this.weight;
        set => SetProperty(ref this.weight, value, true);
    }

    [Required]
    [Range(0, 2.5)]
    public double Height
    {
        get => this.height;
        set => SetProperty(ref this.height, value, true);
    }

    [Required]
    public string Description
    {
        get => this.description;
        set => SetProperty(ref this.description, value, true);
    }

    public string PositionName
    {
        get => this.positionName;
        set => SetProperty(ref this.positionName, value, true);
    }

    [Required]
    [Range(1, 7)]
    public int PositionId
    {
        get => this.positionId;
        set => SetProperty(ref this.positionId, value, true);
    }


    public PlayerModel() : base()
    {}

    public PlayerModel(int id, string name, string localImageLink, string webImageLink, string club, string birthday, string birthPlace, int weight, double height, string description, string positionName, int positionId) : base()
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
        PositionName = positionName;
        PositionId = positionId;
    }

    public PlayerModel(int id, string name, string localImageLink, string webImageLink, string club, string birthday, string birthPlace, int weight, double height, string description, PositionModel position) : base()
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
        PositionName = position.Name;
        PositionId = position.Id;
    }

    public PlayerModel(PlayerEntity player)
    {
        Id = player.Id;
        Name = player.Name;
        LocalImageLink = player.LocalImageLink;
        WebImageLink = player.WebImageLink;
        Club = player.Club;
        Birthday = player.Birthday;
        BirthPlace = player.BirthPlace;
        Weight = player.Weight;
        Height = player.Height;
        Description = player.Description;
        PositionName = player.Position.Name;
        PositionId = player.Position.Id;
    }

    public PlayerEntity ToEntity()
    {
        return new PlayerEntity
        {
            Id = Id,
            Name = Name,
            LocalImageLink = LocalImageLink,
            WebImageLink = WebImageLink,
            Club = Club,
            Birthday = Birthday,
            BirthPlace = BirthPlace,
            Weight = Weight,
            Height = Height,
            Description = Description,
            Position = new PositionEntity
            {
                Id = PositionId,
                Name = PositionName
            }
        };
    }

    public void ToEntity(PlayerEntity player)
    {
        player.Id = Id;
        player.Name = Name;
        player.LocalImageLink = LocalImageLink;
        player.WebImageLink = WebImageLink;
        player.Club = Club;
        player.Birthday = Birthday;
        player.BirthPlace = BirthPlace;
        player.Weight = Weight;
        player.Height = Height;
        player.Description = Description;

        player.Position.Id = PositionId;
        player.Position.Name = PositionName;
    }
}