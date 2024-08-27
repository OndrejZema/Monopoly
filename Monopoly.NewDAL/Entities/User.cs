﻿namespace Monopoly.NewDAL.Entities;

public class User
{
    public long? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; } = true;
    public string PasswordHash { get; set; }
    public ICollection<Game> Games { get; set; }
}