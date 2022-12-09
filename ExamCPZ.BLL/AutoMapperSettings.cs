using AutoMapper;
using ExamCPZ.BLL.Models;
using ExamCPZ.DAL.Entities;

namespace ExamCPZ.BLL
{
    public class AutoMapperSettings : Profile
    {
        public AutoMapperSettings()
        {
            CreateMap<Patient, PatientModel>()
                .ReverseMap();
            CreateMap<Appointment, AppointmentModel>()
                .ReverseMap();
        }
    }
}