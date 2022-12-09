using System.ComponentModel.DataAnnotations;

namespace ExamCPZ.BLL.Models
{ 
    public class AppointmentModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public PatientModel Patient { get; set; }
    }
}
