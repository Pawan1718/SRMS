using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRMS.Models
{
    public class StudentModel
    {
        [Key]
        public int RollNo { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FName { get; set; }
        [Required]
        [DisplayName("Father Name")]
        public string MName { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string LName { get; set; }
        [DisplayName("Contact Number")]
        public int Contact { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public string DOB { get; set; }
        public int Age { get; set; }
        [DisplayName("Standerd in Words")]
        public string StanderdInWord { get; set; }
        [DisplayName("Standerd in Numeric")]
        public int StanderdInNumeric { get; set; }
        public string Address { get; set; }

        public string FullName => $"{FName} {MName} {LName}";
    
    }
}
