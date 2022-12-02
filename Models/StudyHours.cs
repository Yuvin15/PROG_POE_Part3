namespace PROG_POE_Part3.Models
{
    public class StudyHours
    {
        public string StudyHoursID { get; set; }
        
        public string TotalStudyHours { get; set; } 

        public string Module_Code { get; set; }
        public string Username { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}
