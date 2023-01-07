﻿namespace Backend.Infrastructure.Constants;

public static class EndPoints
{
    public static class Player
    {
        public const string GetAllAsync = "players/get-all";
        public const string DeleteAsync = "players/delete";
        public const string CreateAsync = "players/create";
        public const string UpdateAsync = "players/update";
        public const string GetByIdAsync = "players";
        public const string GetPageAsync = "players/page";
    }

    public static class Position
    {
        public const string GetAllAsync = "positions/get-all";
    }
}
