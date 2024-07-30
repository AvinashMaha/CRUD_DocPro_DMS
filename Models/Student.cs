using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_DocPro_DMS.Models
{
    public class Student
    {
        [Key]
        [Column("Student_Id")]
        [Required]
        public int Student_Id { get; set; }


        [Required]
        [Column(TypeName ="varchar(100)")]
        public string Name { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Course { get; set; }


        [Required]
        public int Age { get; set; }

        [Required]
        [Column(TypeName ="varchar(100)")]
        public string Education { get; set; }
    }
}
