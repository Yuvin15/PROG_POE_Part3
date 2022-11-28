using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PROG_POE_Part3.Models;

public partial class User
{
    [DisplayName("Username")]
    public string Username { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public string HashedPassword { get; set; }

    public virtual ICollection<Module> Modules { get; } = new List<Module>();
}
