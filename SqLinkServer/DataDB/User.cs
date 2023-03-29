using System;
using System.Collections.Generic;

namespace SqLinkServer.DataDB;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Team { get; set; }

    public DateTime? JoinedAt { get; set; }

    public string? Avatar { get; set; }
}
