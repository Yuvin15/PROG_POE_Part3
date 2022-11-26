using System;
using System.Collections.Generic;

namespace PROG_POE_Part3.Models;

public partial class User
{
    public string Username { get; set; }

    public string Password { get; set; }

    public string HashedPassword { get; set; }

    public virtual ICollection<Module> Modules { get; } = new List<Module>();
}
