using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PROG_POE_Part3.Models;

public partial class User
{
    [DisplayName("Username")]
    [Required(ErrorMessage ="Field is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Field is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public virtual ICollection<Module> Modules { get; } = new List<Module>();
}
