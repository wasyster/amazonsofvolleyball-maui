namespace Backend.Infrastructure.Constants;

public static class EndPoint
{
    public static class Player
    {
        public const string GetAllAsync = "players/get-all";
        public const string DeleteAsync = "players/delete";
    }

    public static class Position
    {
        public const string GetAllAsync = "positions/get-all";
    }
}
