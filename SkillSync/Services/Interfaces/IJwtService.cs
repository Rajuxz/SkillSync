﻿namespace SkillSync.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string email, string role = "User");
    }
}
