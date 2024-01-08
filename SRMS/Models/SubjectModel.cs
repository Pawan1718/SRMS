using System.ComponentModel.DataAnnotations;

namespace SRMS.Models
{
    public class SubjectModel
    {
        [Key]
        public int Id { get; set; }
        public  int Std { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }

    }
}
