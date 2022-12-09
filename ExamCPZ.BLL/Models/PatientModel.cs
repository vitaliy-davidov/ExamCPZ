using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCPZ.BLL.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string Diagnosis { get; set;}
    }
}
