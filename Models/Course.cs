namespace PROG_POE_Part3.Models
{
    public class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }  
        public string Module_Code { get; set; }
        public string StudyHoursID { get; set; }    
        public string Username { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}
