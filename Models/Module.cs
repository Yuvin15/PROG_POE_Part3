using System;
using System.Collections.Generic;

namespace PROG_POE_Part3.Models;

public partial class Module
{
    public string ModuleCode { get; set; }

    public string ModuleName { get; set; }

    public string ModuleCredits { get; set; }

    public string ClassHours { get; set; }

    public string SelfStudyTotal { get; set; }  

    public string SelfStudyCompleted { get; set; }

    public string Username { get; set; }

    public virtual User UsernameNavigation { get; set; }

}
