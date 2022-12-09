using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCPZ.DAL.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string OwnerSurname { get; set; }
        [Required]
        public string Diagnosis { get; set;}

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
