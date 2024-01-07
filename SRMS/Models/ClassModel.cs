using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SRMS.Models
{
    public class ClassModel
    {
        [Key]
        public int Id { get; set; }
        public  string ClassInWord { get; set; }
        public int ClassInNumeric { get; set;}
        public string Section { get; set; }
    }
}
