using System.ComponentModel.DataAnnotations;

namespace ExamCPZ.DAL.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
    }
}
